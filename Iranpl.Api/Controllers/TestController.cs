using Iranpl.ApplicationCore.Services.Implementations.Messages;
using Iranpl.ApplicationCore.Services.Intefaces.Messages;
using Iranpl.ApplicationCore.Services.Intefaces.Test;
using Iranpl.Domain.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Iranpl.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ITestLogin _testLogin;
        public TestController(ITestLogin testLogin)
        {
            _testLogin = testLogin;
        }
        [HttpGet] 
        public ActionResult Index()
        {
            return Ok();
        }
        [HttpPost]
       // public IActionResult Authenticate(TestLoginModel testLogin)
        public IActionResult PostAuthenticate(string userName, string password)
        {
            var testLogin = new TestLogin()
            {
                UserName = userName,
                Password = password
            };
            var result = _testLogin.TestLogin(testLogin);

            if (!result.UserName.IsNullOrEmpty())
            {
                //ToDo: Claim 
                //
                //token
                //userId as Guid

            }
            else
            {
                return BadRequest();
            }
            
            return Ok();
        }   
    }
}
