using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iranpl.Domain.Models.ApiModels
{
    [Table("Townships")]

    public class Township
    {
        [Key]
        public int TownshipCode { get; set; }
        [StringLength(50)]
        public string? TownshipName { get; set; }
        public int StateCode { get; set; }

        [ForeignKey("StateCode")]
        public State State { get; set; }
    }
}
