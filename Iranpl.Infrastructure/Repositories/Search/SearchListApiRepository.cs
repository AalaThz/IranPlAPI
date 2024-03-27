using Iranpl.Domain.Models.SearchModels;
using Iranpl.Infrastructure.Data.IranplContext;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Iranpl.ApplicationCore.Services.Intefaces.Search;
using Iranpl.Domain.ViewModel;
using AngleSharp.Css.Dom;
using AngleSharp.Dom;

namespace Iranpl.Infrastructure.Repositories.Search
{
    public class SearchListApiRepository : ISearchApiRepository
    {
        private readonly SearchListsApiContext _apiContext;

        public SearchListApiRepository(SearchListsApiContext apiContext)
        {
            _apiContext = apiContext;
        }



        private string CreateSearchPart(string tblName, string queryStatement, string Types)
        {
            return " and " + tblName + " like N'" + qsFinal(queryStatement.Trim(), Types) + "' ";
        }

        private string qsFinal(string QS, string Types)
        {
            if (Types == "1")
                QS = QS.Trim() + "%";
            else if (Types == "2")
            {
                QS = "%" + QS.Trim() + "%";
            }
            else
            {
                QS = QS.Trim();
            }
            return QS;
        }

        public List<BP_FehrestSearchResults> BP_FehrestSearchResult(Bp_ModelForSearch bp_Model,
            string onvan, string padidAvar, string tarikhNashr, string nasher, string mahalNashr, string RecordNumber)
        {
            onvan = onvan.Replace(" ", "%");
            padidAvar = padidAvar.Replace(" ", "%");
            nasher = nasher.Replace(" ", "%");
            mahalNashr = mahalNashr.Replace(" ", "%");

            #region MyRegion

            


            #region CreatingWhereClause
            string WhereClause = "";
            if (!string.IsNullOrEmpty(onvan) && !string.IsNullOrWhiteSpace(onvan))
            {
                WhereClause += CreateSearchPart("title", onvan, bp_Model.SearchType.ToString());
            }
            if (!string.IsNullOrEmpty(padidAvar) && !string.IsNullOrWhiteSpace(padidAvar))
            {
                WhereClause += CreateSearchPart("creator", padidAvar, bp_Model.SearchType.ToString());
            }
            if (!string.IsNullOrEmpty(nasher) && !string.IsNullOrWhiteSpace(nasher))
            {
                WhereClause += CreateSearchPart("publisher", nasher, bp_Model.SearchType.ToString());
            }
            if (!string.IsNullOrEmpty(tarikhNashr) && !string.IsNullOrWhiteSpace(tarikhNashr))
            {
                WhereClause += CreateSearchPart("publishDate", tarikhNashr, bp_Model.SearchType.ToString());
            }
            if (!string.IsNullOrEmpty(mahalNashr) && !string.IsNullOrWhiteSpace(mahalNashr))
            {
                WhereClause += CreateSearchPart("b210a.a", mahalNashr, bp_Model.SearchType.ToString());
            }
            if (!string.IsNullOrEmpty(RecordNumber) && !string.IsNullOrWhiteSpace(RecordNumber))
            {
                WhereClause += CreateSearchPart("[Mark2].[dbo].[BlockRecord].[RecordNumber]", RecordNumber, bp_Model.SearchType.ToString());
            }
            #endregion
            // ================ This part is for OrgIdType ==========================================
            if (bp_Model.OrgIdType > 0)
            {
                WhereClause += CreateSearchPart("[Mark2].[dbo].[BlockRecord].[OrgId]", bp_Model.OrgIdType.ToString(), bp_Model.SearchType.ToString());
            }
            //#endregion
            //var result1 = new List<BP_FehrestSearchResults>();
            //var outParam = new SqlParameter();
            //outParam.ParameterName = "RecordCount";
            //outParam.SqlDbType = SqlDbType.Int;
            //outParam.Direction = ParameterDirection.Output;

            //result1 = _apiContext.Database.SqlQuery<BP_FehrestSearchResults>("sp_FSearch_BlindPeople1 @Query2,@PageIndex,@PageSize,@zaban,@MaterialID,@order,@RecordCount OUT",
            //                                                      new SqlParameter("Query2", WhereClause),
            //                                                      new SqlParameter("PageIndex", bp_Model.PageIndex),
            //                                                      new SqlParameter("PageSize", bp_Model.PageSize),
            //                                                      new SqlParameter("zaban", bp_Model.Language),
            //                                                      new SqlParameter("MaterialID", bp_Model.MaterialID),
            //                                                      new SqlParameter("order", bp_Model.order),
            //                                                      outParam
            //   ).ToList();
            var zaban = 33;// bp_Model.Language;
            var MaterialID = 1;
            long RecordCount = 1;
            var result2 = _apiContext.BP_FehrestSearchResults.FromSqlInterpolated(
                 $"sp_FSearch_BlindPeople1 {WhereClause}, {bp_Model.PageIndex} ,{bp_Model.PageSize} ,{bp_Model.Language} ,{bp_Model.MaterialID} ,{bp_Model.order},{RecordCount}"
                 ).ToList();

            return result2;
        }
    }
}








// add comment

//public List<BP_FehrestSearchResults> BP_FehrestSearch(Bp_ModelForSearch bp_Model, string onvan,
//    string padidAvar, string nasher, string tarikhNashr, string mahalNashr, 
//    string RecordNumber)
//{

//    string WhereClause = "";
//    if (!string.IsNullOrEmpty(onvan) && !string.IsNullOrWhiteSpace(onvan))
//    {
//        WhereClause += CreateSearchPart("title", onvan, bp_Model.SearchType.ToString());
//    }
//    var zaban = 33;// bp_Model.Language;
//    var MaterialID = 1;
//    long RecordCount = 1;

//    var result1 = new List<BP_FehrestSearchResults>();

//    // کد آقای منصف
//    var result =
//         _apiContext.BP_FehrestSearchResults.FromSqlInterpolated(
//             $"sp_FSearch_BlindPeople1 {WhereClause}, {bp_Model.PageIndex} ,{bp_Model.PageSize} ,{zaban} ,{MaterialID} ,{bp_Model.order},{RecordCount}"
//              ).ToList();
//    return result;
//}

#endregion