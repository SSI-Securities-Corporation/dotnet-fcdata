
namespace SSI.FCData.Models.Request
{
    public class IntradayOHLCRequest
    {
        public string Symbol { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 10000;
        public int Resolution { get; set; } = 10;

        public bool ascending { get; set; } = false;
    }
}
