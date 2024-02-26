using Iranpl.ApplicationCore.Services.DTO.State;
using Iranpl.ApplicationCore.Services.DTO.Township;
using Iranpl.ApplicationCore.Services.Implementations;
using Iranpl.Domain.Models.ApiModels;
using Iranpl.Infrastructure.Data.IranPlDbContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Iranpl.Api.Controllers
{
    [Route("api/[controller]")] //localhost:port/api/state
    [ApiController]
    [SwaggerTag(" (اطلاعات استان های ایران) ")]


    public class StateController : ControllerBase
    {
        private readonly StateService _stateService;
        
        public StateController(StateService stateService)
        {
            _stateService = stateService;
        }

        /// <summary>
        /// دریافت فهرست همه استان های ایران
        /// </summary>
        /// <returns>فهرست استان ها</returns>
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
        /// <summary>
        ///  (Id) جستجوی استان با
        /// </summary>
        ///<param name="id">هر استان است statecode نشان دهنده id  </param>
        /// <returns>استان با (Id) مورد نظر</returns>
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
