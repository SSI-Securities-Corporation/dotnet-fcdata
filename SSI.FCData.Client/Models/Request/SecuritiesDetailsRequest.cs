

namespace SSI.FCData.Models.Request
{
    public class SecuritiesDetailsRequest
    {
        public string Market { get; set; }
        public string Symbol { get; set; }
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
