using Iranpl.ApplicationCore.Services.DTO.Geographical;
using Iranpl.ApplicationCore.Services.Implementations.Geographical;
using Iranpl.Domain.Models.ApiModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel;

namespace Iranpl.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("(اطلاعات روستاهای ایران)")]
    public class VillageController : ControllerBase
    {
        private readonly VillageService _villageService;

        public VillageController(VillageService villageService)
        {
            _villageService = villageService;
        }
        //GET VILLAGE BY ID
        /// <summary>
        ///  (Id) جستجوی روستا با
        /// </summary>
        ///<param name="id">هر روستا است VillageCode نشان دهنده id  </param>
        /// <returns>روستا با (Id) مورد نظر</returns>
        [HttpPost]
        [Route("{id}")] //localhost:port/api/village/{id}
        public IActionResult GetVillageById([FromRoute] int id)
        {
            var village = _villageService.GetVillageById(id);
            if (village == null)
            {
                return BadRequest(new
                {
                    Error = $"Village with id = {id} is not found",
                    Title = "Record is not found",
                    Status = 400
                });
            }

            var villageDto = new VillageDto
            {
                VillageCode = village.VillageCode,
                VillageName = village.VillageName,
                PartCode = village.PartCode, 
            };
            return Ok(new { Message = "The Village was found", Date = villageDto });
        }

        //GET VILLAGE BY PART ID
        /// <summary>
        /// استان (Id) دریافت فهرست همه روستاهای ایران با
        /// </summary>
        ///<param name="partId">هر بخش است partCode نشان دهنده partId  </param>
        /// <returns>روستا با (Id) مورد نظر</returns>
        [HttpPost("getVillageByPartId/{partId}")] //localhost:port/api/township/getVillagesByPartId/{partid}
        
        public IActionResult GetVillagesByPartId(int partId)
        {
            var village = _villageService.GetVillageByPartId(partId);
            if (village.Count == 0)
            {
                return BadRequest(new
                {
                    Error = $"Village with id = {partId} is not found",
                    Title = "Record is not found",
                    Status = 400
                });
            }
            var villageDto = village.Select(v => new VillageDto
            {
                VillageCode = v.VillageCode,
                VillageName = v.VillageName,
                PartCode = v.PartCode,
            }).ToList();

            return Ok(new { Message = "The Village was found by Part id", DateOnly = villageDto });
        }
    }
}
