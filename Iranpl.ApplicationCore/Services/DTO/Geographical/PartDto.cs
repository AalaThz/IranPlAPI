using Iranpl.ApplicationCore.Services.DTO.Geographical;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iranpl.ApplicationCore.Services.DTO.Geographical
{
    public class PartDto
    {
        public int PartCode { get; set; }
        public string? PartName { get; set; }
        public int TownshipCode { get; set; }
    }
}
