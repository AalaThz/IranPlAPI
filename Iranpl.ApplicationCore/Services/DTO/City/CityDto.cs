using Iranpl.ApplicationCore.Services.DTO.Part;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iranpl.ApplicationCore.Services.DTO.City
{
    public class CityDto
    {
        public int CityCode { get; set; }
        public string? CityName { get; set; }
        public int PartCode { get; set; }
    }
}
