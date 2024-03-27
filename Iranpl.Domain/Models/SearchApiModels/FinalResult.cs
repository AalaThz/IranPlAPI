using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iranpl.Domain.Models.SearchModels
{
    public class FinalResult<T>
    {
        public string StatusPhrase { get; set; }
        public int Status { get; set; }
        public int TotalCount { get; set; }
        public int TotalPage { get; set; }
        public int Count { get; set; }
        public int CurrentPage { get; set; }
        public IList<T> Results { get; set; } = new List<T>();
    }
}
