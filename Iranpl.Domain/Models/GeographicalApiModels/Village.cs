using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iranpl.Domain.Models.ApiModels
{
    [Table("Villages")]
    public class Village
    {
        [Key]
        public int VillageCode { get; set; }
        [StringLength(200)]
        public string? VillageName { get; set; }
        public int PartCode { get; set; }
        [ForeignKey("PartCode")]
        public Part Part { get; set; }
    }
}
