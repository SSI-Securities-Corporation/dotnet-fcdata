
namespace SSI.FCData.Models.Request
{
    public class DailyIndexRequest
    {
        public string RequestId { get; set; }
        public string IndexId { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string OrderBy { get; set; }
        public string Order { get; set; }
        public bool ascending { set; get; } = false;
    }
}
