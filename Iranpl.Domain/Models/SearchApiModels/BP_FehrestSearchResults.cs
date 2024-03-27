using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iranpl.Domain.Models.SearchModels
{
    public class BP_FehrestSearchResults
    {
        public long RowNumber { get; set; }
        public long RecordNumber { get; set; }
        public string OnvanAsli { get; set; }
        public string Padidavarande { get; set; }
        public string saleNashr { get; set; }
        public string nasher { get; set; }
        public string mahalNashr { get; set; }
        public string code { get; set; }
        //public int Rt { get; set; }
        //public string AllStuffnashr { get; set; }
        public int RecordCount { get; set; }
    }
}
