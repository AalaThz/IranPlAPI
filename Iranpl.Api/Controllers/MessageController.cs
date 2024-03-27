using Azure.Core;
using Iranpl.ApplicationCore.Services.Implementations.Messages;
using Iranpl.Domain.ViewModel.Users;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Runtime.InteropServices.JavaScript;
using System.Security.Claims;
using System.Security.Cryptography.Xml;
using System.Text.Json;
using System.Text.Json.Nodes;
using Iranpl.ApplicationCore.Services.Intefaces.Messages;

namespace Iranpl.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMassageListRepository _listRepository;
        public MessageController(IMassageListRepository listRepository)
                {
                    _listRepository = listRepository;
                }


        [HttpGet]
        //[Authorize]
        public async Task<IActionResult> MsgList()
        {
            var model = new UserInfoViewModel();

            //var token1 = _listRepository.GetAllMsgList(token);


            HttpResponseMessage response;
            JsonObject finalResult;

            if (User.Identity.IsAuthenticated)
            {
                Guid id = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == "UserId").Value ?? Guid.NewGuid().ToString());
                string token = User.Claims.FirstOrDefault(c => c.Type == "Token").Value;

                List<MessageContainer> list = await _listRepository.GetAllMsgList(token);
                return Ok(list) ;
            }

            else
            {
                return BadRequest();
            }
            ////MessageListResult result = new MessageListResult()
            ////{
            ////    StatusPhrase = "ok",
            ////    Status = 1,
            ////    MessageContainers = _listRepository.GetAllMsgList(id),
            ////};

            //// Serialize the result object to JSON
            //string json = JsonSerializer.Serialize(result);

            //// Parse the JSON string to a JsonDocument
            //using JsonDocument jsonDoc = JsonDocument.Parse(json);

            //// Create a new OkObjectResult with the JSON content
            //return new OkObjectResult(jsonDoc.RootElement);
            //}

        }
    }
}