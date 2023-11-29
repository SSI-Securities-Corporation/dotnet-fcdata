

namespace SSI.FCData.Models.Request
{
    public class StockPriceRequest
    {
        public string Symbol { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string Market { get; set; }
    }
}
