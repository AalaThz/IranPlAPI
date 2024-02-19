using Iranpl.ApplicationCore.Services.DTO.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iranpl.ApplicationCore.Services.DTO.Township
{
    public class TownshipDto
    {
        public int TownshipCode { get; set; }
        public string? TownshipName { get; set; }
        public int StateCode { get; set; }

    }
}
