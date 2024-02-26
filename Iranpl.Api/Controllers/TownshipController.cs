using Iranpl.ApplicationCore.Services.DTO.State;
using Iranpl.ApplicationCore.Services.DTO.Township;
using Iranpl.ApplicationCore.Services.Implementations;
using Iranpl.Domain.Models.ApiModels;
using Iranpl.Infrastructure.Data.IranPlDbContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Iranpl.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("(اطلاعات شهرستان های ایران)")]
    public class TownshipController : ControllerBase
    {
        private readonly TownshipService _townshipService;
        public TownshipController(TownshipService townshipService)
        {
            _townshipService = townshipService;
        }

        //GET ALL TOWNSHIP
        /// <summary>
        /// دریافت فهرست همه شهرستان های ایران
        /// </summary>
        /// <returns>فهرست شهرستان ها</returns>
        [HttpGet]
        public IActionResult GetAllTownship()
        {
            var township = _townshipService.GetAllTownship();
            var townshipDto = township.Select(t => new TownshipDto
            {
                TownshipCode = t.TownshipCode,
                TownshipName = t.TownshipName,
                StateCode = t.StateCode,
            }).ToList();
            return Ok(new { Message = "Get All Townships", Date = townshipDto } );
        }

        //GET TOWNSHIP BY ID
        /// <summary>
        ///  (Id) جستجوی شهرستان با
        /// </summary>
        ///<param name="id">هر شهرستان است townshipcode نشان دهنده id  </param>
        /// <returns>شهرستان با (Id) مورد نظر</returns>
        [HttpPost]
        [Route("{id}")] //localhost:port/api/township/{id}
        public IActionResult PostTownshipById([FromRoute] int id)
        {
            var township = _townshipService.GetTownshipById(id);
            if (township == null)
            {
                return BadRequest(new
                {
                    Error = $"Township with id = {id} is not found",
                    Title = "Record is not found",
                    Status = 400
                });
            }
            var townshipDto = new TownshipDto
            {
                TownshipCode = township.TownshipCode,
                TownshipName = township.TownshipName,
                StateCode = township.StateCode,

            };
            return Ok(new { Message = "The Township was found.", Date = townshipDto });
        }

        //POST TOWNSHIPS BY STATE ID
        /// <summary>
        /// استان (Id) دریافت فهرست همه شهرستان های ایران با
        /// </summary>
        ///<param name="stateId"> هر شهرستان است statecode نشان دهنده stateid</param>
        /// <returns>شهرستان با (Id) مورد نظر</returns>
        [HttpPost("getTownshipsByStateId/{stateId}")]//localhost:port/api/township/GetTownshipsByStateId/{stateid}
        public IActionResult GetTownshipsByStateId([FromRoute] int stateId)
        {
            var townships = _townshipService.GetTownshipsByStateId(stateId);
            if (townships.Count == 0)
            {
                return BadRequest(new
                {
                    Error = $"Township with stateId = {stateId} is not found",
                    Title = "Record is not found",
                    Status = 400
                });
            }
            var townshipDto = townships.Select(t => new TownshipDto
            {
                TownshipCode = t.TownshipCode,
                TownshipName = t.TownshipName,
                StateCode = t.StateCode,
            }).ToList();
            return Ok(new { Message = "The Township was found by State id", Date = townshipDto });
        }
        
    }
}
