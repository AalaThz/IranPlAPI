using AngleSharp;
using Iranpl.Domain.ViewModel;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Iranpl.ApplicationCore.Services.Implementations.Messages
{
    public class TestAuthenticationService
    {
        public string AuthenticateUser(TestLogin user)
        {
            string result = "";
            if (user.UserName == "admin" && user.Password == "password")
            {
                result = "ok";
            }
            return result;

        }



        //private readonly IConfiguration _config;

        //public TestAuthenticationService(IConfiguration config)
        //{
        //    _config = config;
        //}

        //public string AuthenticateUser(TestLoginModel user)
        //{
        //    if (user.UserName == "admin" && user.Password == "password")
        //    {
        //        // Generate JWT token
        //        var token = GenerateJwtToken(user.UserName);
        //        return token;
        //    }

        //    return null;
        //}
        //private string GenerateJwtToken(string username)
        //{
        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var key = Encoding.ASCII.GetBytes(_config["Jwt:SecretKey"]);
        //    var tokenDescriptor = new SecurityTokenDescriptor
        //    {
        //        Subject = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, username) }),
        //        Expires = DateTime.UtcNow.AddHours(1),
        //        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        //    };
        //    var token = tokenHandler.CreateToken(tokenDescriptor);
        //    return tokenHandler.WriteToken(token);
        //}
    }
}
