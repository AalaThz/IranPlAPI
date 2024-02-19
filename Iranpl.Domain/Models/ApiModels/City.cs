using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iranpl.Domain.Models.ApiModels
{
    [Table("Cities")]
    public class City
    {
        [Key]
        public int CityCode { get; set; }

        [StringLength(50)]
        public string? CityName { get; set; }
        public int PartCode { get; set; }

        [ForeignKey("PartCode")]
        public Part Part { get; set; }
    }
}
