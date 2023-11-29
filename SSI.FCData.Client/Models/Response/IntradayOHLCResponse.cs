
namespace SSI.FCData.Models.Response
{
    public class IntradayOHLCResponse : ResponseBase<IntradayOHLCResponseModel>
    {
    }
    public class IntradayOHLCResponseModel
    {
        public string Symbol { get; set; }
        public string Value { get; set; }
        public string TradingDate { get; set; }
        public string Time { get; set; }
        public string Open { get; set; }
        public string High { get; set; }
        public string Low { get; set; }
        public string Close { get; set; }
        public string Volume { get; set; }
    }
}
