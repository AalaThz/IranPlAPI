using AngleSharp.Css.Dom;
using Azure;
using Iranpl.ApplicationCore.Services.Intefaces.Search;
using Iranpl.Domain.Models.SearchModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iranpl.ApplicationCore.Services.Implementations.Search
{
    public class FehrestSearchService
    {
        private readonly ISearchApiRepository _apiRepository;

        public FehrestSearchService(ISearchApiRepository apiRepository)
        {
            _apiRepository = apiRepository;
        }

        public List<BP_FehrestSearchResults> BP_FehrestSearchResults(Bp_ModelForSearch bp_Model,
            string onvan, string padidAvar, string nasher, string tarikhNashr, string mahalNashr, string RecordNumber)
        {
            return _apiRepository.BP_FehrestSearchResult(bp_Model, onvan, padidAvar, nasher, tarikhNashr, mahalNashr, RecordNumber);
        }

        //public List<BP_FehrestSearchResults> BP_FehrestSearchResults(string onvan, string padidAvar, string nasher, string tarikhNashr, string mahalNashr, string recordNumber)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
