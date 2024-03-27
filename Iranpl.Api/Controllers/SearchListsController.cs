using Iranpl.ApplicationCore.Services.Implementations.Search;
using Iranpl.Domain.Models.SearchModels;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Services;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Linq;

namespace Iranpl.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchListsController : ControllerBase
    {
        private readonly FehrestSearchService _bp_FehretService;
        public SearchListsController(FehrestSearchService bp_FehretService)
        {
            _bp_FehretService = bp_FehretService;
        }
        [HttpGet]

        //جواب داده 
        //public IActionResult bp_fehrestSearch(int OrgIdType, string? order, string? searchType, string? MaterialID,
        //    string? Language, string? onvan, string? padidAvar, string? nasher, string? tarikhNashr, string? mahalNashr,
        //    string? RecordNumber, int Pagesize = 10, int Page = 1)

        public IActionResult bp_fehrestSearch(string? OrgIdType, int? Page, int? Pagesize, string? order,
            string? searchType, string? MaterialID, string? Language,
            string? onvan, string? padidAvar, string? nasher, string? tarikhNashr, string? mahalNashr, string? RecordNumber)
        {
            HttpResponseMessage response;
            onvan = onvan ?? "";
            padidAvar = padidAvar ?? "";
            nasher = nasher ?? "";
            tarikhNashr = tarikhNashr ?? "";
            mahalNashr = mahalNashr ?? "";
            RecordNumber = RecordNumber ?? "";
            OrgIdType = OrgIdType ?? "10101010";

            Bp_ModelForSearch bp_ModelForSearch = new Bp_ModelForSearch();

            bp_ModelForSearch.PageSize = (int)Pagesize;
            bp_ModelForSearch.PageIndex =(int) Page;
            bp_ModelForSearch.Language = Convert.ToInt32(Language);
            bp_ModelForSearch.MaterialID = Convert.ToInt32(MaterialID);
              //bp_ModelForSearch.Language = Language;
           // bp_ModelForSearch.MaterialID = MaterialID;



            if (!string.IsNullOrWhiteSpace(order) && !string.IsNullOrEmpty(order))
            {
            #region Test
            string fieldName = "";
            switch (order)
            {
                case "onvan_a":
                    fieldName = "title asc";
                    break;
                case "onvan_d":
                    fieldName = "title desc";
                    break;
                case "author_a":
                    fieldName = "creator asc";
                    break;
                case "author_d":
                    fieldName = "creator desc";
                    break;
                case "publisher_a":
                    fieldName = "publisher asc";
                    break;
                case "publisher_d":
                    fieldName = "publisher desc";
                    break;
                case "Pyear_a":
                    fieldName = "publishDate asc";
                    break;
                case "Pyear_d":
                    fieldName = "publishDate desc";
                    break;
                default:
                    fieldName = "title asc";
                    break;
            }
                #endregion
                //bp_ModelForSearch.order = orderF(order);
                bp_ModelForSearch.order = fieldName;
            }

            //List<BP_FehrestSearchResults> resultData = _bp_FehretService.BP_FehrestSearchResults(bp_ModelForSearch, onvan,
            List<BP_FehrestSearchResults> resultData = _bp_FehretService.BP_FehrestSearchResults(bp_ModelForSearch, onvan,
                padidAvar, nasher, tarikhNashr, mahalNashr, RecordNumber);


            return Ok(resultData);
        }
    }

}
