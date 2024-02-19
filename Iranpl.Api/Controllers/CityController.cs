using Iranpl.ApplicationCore.Services.DTO.City;
using Iranpl.ApplicationCore.Services.Implementations;
using Iranpl.Domain.Models.ApiModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Iranpl.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly CityService _cityService;
        public CityController(CityService cityService)
        {
            _cityService = cityService;
        }

        //GET ALL PART
        [HttpGet("getAll")]
        public IActionResult GetAllCity()
        {
            var city = _cityService.GetAllCities();
            var cityDto = city.Select(c => new CityDto
            {
                CityCode = c.CityCode,
                CityName = c.CityName,
                PartCode = c.PartCode,
            }).ToList();
            return Ok(new { Message = "Get All Cities", Date = cityDto });
        }

        //GET STATE BY ID
        [HttpPost]
        [Route("{id}")] //localhost:port/api/city/{id}
        public IActionResult GetCityById([FromRoute] int id)
        {
            var city = _cityService.GetCityById(id);
            if (city == null)
            {
                return BadRequest(new
                {
                    Error = $"City with id = {id} is not found",
                    Title = "Record is not found",
                    Status = 400
                });
            }
            var cityDto = new CityDto
            {
                CityCode = city.CityCode,
                CityName = city.CityName,
                PartCode = city.PartCode,
            };
            return Ok(new { Message = "The City was found", Date = cityDto });
        }

        //GET CITY BY PART ID
        [HttpPost("getCityByPartId/{partId}")] //localhost:port/api/township/getCityByPartId/{partid}
        public IActionResult GetCitiesByPartId(int partId=0)
        {
            var city = _cityService.GetCitiesByPartId(partId);
            if (city.Count == 0)
            {
                return BadRequest(new
                {
                    Error = $"City with partId = {partId} is not found",
                    Title = "Record is not found",
                    Status = 400
                });
            }
            var cityDto = city.Select(c => new CityDto
            {
                CityCode = c.CityCode,
                CityName = c.CityName,
                PartCode = c.PartCode,
            }).ToList();
            return Ok(new {Message = "The City was found by Part id", DateOnly = cityDto});
        }

    }
}
