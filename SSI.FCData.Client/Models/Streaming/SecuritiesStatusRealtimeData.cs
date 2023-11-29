
namespace SSI.FCData.Models.Streaming
{
    public class SecuritiesStatusRealtimeData
    {
        public string RType { get; set; }
        public string MarketId { get; set; }
        public string ReportDate { get; set; }

        public string Symbol { get; set; }

        public string TradingSession { get; set; }

        public string TradingStatus { get; set; }
    }
}
