

namespace SSI.FCData.Models.Streaming
{
    public class ForeignRoomRealtimeData
    {
        public string Rtype { get; set; }
        public string TradingDate { get; set; }
        public string TradingTime { get; set; }
        public string Isin { get; set; }

        public string Symbol { get; set; }

        public decimal TotalRoom { get; set; }

        public decimal CurrentRoom { get; set; }

        public decimal FBuyVol { get; set; }

        public decimal FSellVol { get; set; }

        public decimal FBuyVal { get; set; }

        public decimal FSellVal { get; set; }
    }
}
