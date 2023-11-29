
namespace SSI.FCData.Models.Request
{
    public class SecuritiesListRequest
    {
        public string Market { get; set; }
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}