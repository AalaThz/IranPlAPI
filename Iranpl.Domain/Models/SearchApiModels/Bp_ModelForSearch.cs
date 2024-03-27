namespace Iranpl.Domain.Models.SearchModels
{
    public class Bp_ModelForSearch
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int Language { get; set; }
        public int MaterialID { get; set; }
        public string order { get; set; }
        public int OrgIdType { get; set; }
        public int SearchType { get; set; }
    }
}
