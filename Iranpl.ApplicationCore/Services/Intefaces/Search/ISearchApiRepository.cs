using Iranpl.Domain.Models.SearchModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iranpl.ApplicationCore.Services.Intefaces.Search
{
    public interface ISearchApiRepository
    {
        List<BP_FehrestSearchResults> BP_FehrestSearchResult(Bp_ModelForSearch bp_Model,
           string onvan, string padidAvar, string tarikhNashr, string nasher, 
           string mahalNashr, string RecordNumber);
        
        //List<BP_FehrestSearchResults> BP_FehrestSearch(Bp_ModelForSearch bp_Model, string onvan, string padidAvar,
        //    string nasher, string tarikhNashr, string mahalNashr, string RecordNumber);
    }
}
