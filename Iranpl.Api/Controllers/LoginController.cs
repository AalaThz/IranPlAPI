using Iranpl.ApplicationCore.Services.Intefaces.Logins;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System.Security.Claims;

namespace Iranpl.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginRepository _loginRepository;
        private readonly IConfiguration _configuration;

        public LoginController(ILoginRepository loginRepository, IConfiguration configuration)
        {
            _loginRepository = loginRepository;
            _configuration = configuration;
        }


        [HttpPost]
        public async Task<IActionResult> Login(string userName , string password)
        {
            var result = "";
            result =await _loginRepository.Login(userName, password);
            if (!result.IsNullOrEmpty())
            {
                //ToDo: Claim 
                var userProfile = await _loginRepository.GetUserInfo(result);

                #region SetCookie
                var claims = new List<Claim>()
                {
                //Guid Need

                new Claim("Token", result),
                new Claim("UserId",userProfile.userId.ToString()),
                //new Claim (ClaimTypes.NameIdentifier, login.UserName.Trim()),
                //new Claim(ClaimTypes.Name, userInfo.Name + " " + userInfo.Family),
                //new Claim("UserId", userInfo.UserId.ToString()),
                };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                var properties = new AuthenticationProperties
                {
                    //IsPersistent = login.RememberMe,
                };
                await HttpContext.SignInAsync(principal, properties);
                #endregion

                return Ok("Login True");
                //token
                //userId as Guid
            }
            else
            {
                return BadRequest();
            }

            //return Ok();

        }
    }
}
