﻿using Iranpl.ApplicationCore.Services.DTO.Part;
using Iranpl.ApplicationCore.Services.DTO.Township;
using Iranpl.ApplicationCore.Services.Implementations;
using Iranpl.Domain.Models.ApiModels;
using Iranpl.Infrastructure.Data.IranPlDbContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Iranpl.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartController : ControllerBase
    {
        private readonly PartService _partService;

        public PartController(PartService partService)
        {
            _partService = partService;
        }

        //GET ALL PART
        [HttpGet("getAll")]
        public IActionResult GetAllParts()
        {
            var part = _partService.GetAllParts();
            var partDto = part.Select(p => new PartDto
            {
                PartCode = p.PartCode,
                PartName = p.PartName,
                TownshipCode = p.TownshipCode,
            }).ToList();

            return Ok(new { Message = "Get All Part", Date = partDto });
        }

        //GET PART BY ID
        [HttpPost]
        [Route("{id}")] //localhost:port/api/part/{id}
        public IActionResult GetPartById([FromRoute] int id)
        {
            var part = _partService.GetPartById(id);
            if (part == null)
            {
                return BadRequest(new
                {
                    Error = $"Part with id = {id} is not found",
                    Title = "Record is not found",
                    Status = 400
                });
            }
            var partDto = new PartDto
            {
                PartCode = part.PartCode,
                PartName = part.PartName,
                TownshipCode = part.TownshipCode,
            };
            return Ok(new { Message = "The Part was founde" ,  Date = partDto });
        }

        [HttpPost("getPartByTownshipId/{townshipId}")] //localhost:port/api/township/getPartByTownshipId/{townshipId}
        public IActionResult GetPartsByTownshipId(int townshipId)
        {
            var part = _partService.GetPartsByTownshipId(townshipId);
            if (part.Count == 0)
            {
                return BadRequest(new
                {
                    Error = $"Part with townshipId = {townshipId} is not found",
                    Title = "Record is not found",
                    Status = 400
                });
            }
            var partDto = part.Select(part => new PartDto
            {
                PartCode = part.PartCode,
                PartName = part.PartName,
                TownshipCode = part.TownshipCode,
            }).ToList();
            return Ok(new { Message = "The Part was found by Towmship id", Date = partDto });
        }
    }
}