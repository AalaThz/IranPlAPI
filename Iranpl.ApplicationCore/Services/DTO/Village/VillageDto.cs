using Iranpl.ApplicationCore.Services.DTO.Part;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iranpl.ApplicationCore.Services.DTO.Village
{
    public class VillageDto
    {
        public int VillageCode { get; set; }
        public string? VillageName { get; set; }
        public int PartCode { get; set; }
    }
}
