﻿using Iranpl.ApplicationCore.Services.DTO.City;
using Iranpl.ApplicationCore.Services.DTO.Village;
using Iranpl.ApplicationCore.Services.Implementations;
using Iranpl.Domain.Models.ApiModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace Iranpl.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillageController : ControllerBase
    {
        private readonly VillageService _villageService;

        public VillageController(VillageService villageService)
        {
            _villageService = villageService;
        }

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
                PartCode = village.VillageCode, 
            };
            return Ok(new { Message = "The Village was found", Date = villageDto });
        }

        //GET CITY BY PART ID
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
                PartCode = v.VillageCode,
            }).ToList();

            return Ok(new { Message = "The Village was found by Part id", DateOnly = villageDto });
        }
    }
}