

namespace SSI.FCData.Models.Streaming
{
    public class BarsRealtimeData
    {
        public string Rtype { get; set; }
        public string Time { get; set; }
        public string Symbol { get; set; }
        public decimal Open { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal Close { get; set; }
        public decimal Volume { get; set; }
        public decimal Value { get; set; }
    }
}
