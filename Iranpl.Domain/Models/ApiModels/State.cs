using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iranpl.Domain.Models.ApiModels
{
    [Table("States")]
    [Description("Everything about your Pets")]
    public class State
    {
        [Key]
        public int StateCode { get; set; }
        [StringLength(100)]
        public string? StateName { get; set; }
    }
}
