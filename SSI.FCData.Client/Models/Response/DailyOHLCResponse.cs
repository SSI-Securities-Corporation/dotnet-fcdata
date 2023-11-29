
namespace SSI.FCData.Models.Response
{
    public class DailyOhlcResponse : ResponseBase<DailyOHLCResponseModel>
    {
    }
    public class DailyOHLCResponseModel
    {
        public string Symbol { get; set; }
        public string Market { get; set; }
        public string TradingDate { get; set; }
        public string Time { get; set; }
        public string Open { get; set; }
        public string High { get; set; }
        public string Low { get; set; }
        public string Close { get; set; }
        public string Volume { get; set; }
        public string Value { get; set; }
    }
}
