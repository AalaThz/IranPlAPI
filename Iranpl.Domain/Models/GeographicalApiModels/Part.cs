using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iranpl.Domain.Models.ApiModels
{
    [Table("parts")]

    public class Part
    {
        [Key]
        public int PartCode { get; set; }
        [StringLength(50)]
        public string? PartName { get; set; }
        public int TownshipCode { get; set; }
        [ForeignKey("TownshipCode")]
        public Township Township { get; set; }
    }
}
