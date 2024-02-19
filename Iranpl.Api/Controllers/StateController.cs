using Iranpl.ApplicationCore.Services.DTO.State;
using Iranpl.ApplicationCore.Services.DTO.Township;
using Iranpl.ApplicationCore.Services.Implementations;
using Iranpl.Domain.Models.ApiModels;
using Iranpl.Infrastructure.Data.IranPlDbContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Iranpl.Api.Controllers
{
    [Route("api/[controller]")] //localhost:port/api/state
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly StateService _stateService;
        
        public StateController(StateService stateService)
        {
            _stateService = stateService;
        }

       
        //GET ALL STATE
        [HttpGet("getAll")]
        public IActionResult GetAllStates()
        {
            var states = _stateService.GetAllState();
            var stateDto = states.Select(s => new StateDto
            {
                StateCode = s.StateCode,
                StateName = s.StateName,
            }).ToList();
            
            return Ok(new { Message = "Get All States", Date = stateDto });
        }

        //GET STATE BY ID
        [HttpPost]
        [Route("{id}")] //localhost:port/api/state/{id}
        public IActionResult PostStateById([FromRoute] int id)
        {
            var stateSingle = _stateService.GetStateById(id);
            if(stateSingle == null)
            {
                return BadRequest(new
                {
                    Error = $"State with id = {id} is not found",
                    Title = "Record is not found",
                    Status = 400
                });
            }
            var stateDto = new StateDto
            {
                StateCode = stateSingle.StateCode,
                StateName = stateSingle.StateName,
            };
            return Ok(new { Message = "The State was found.", Date = stateDto });
        }
    }
}
