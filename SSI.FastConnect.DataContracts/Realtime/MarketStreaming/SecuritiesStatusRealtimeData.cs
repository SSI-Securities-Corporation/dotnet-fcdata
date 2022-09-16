using System;
using System.Runtime.Serialization;

namespace SSI.FastConnect.DataContracts.Realtime
{
    [DataContract]
    public class SecuritiesStatusRealtimeData
    {
        [DataMember(Order = 1, Name = "RType")]
        public string RType { get; set; }

        [DataMember(Order = 2, Name = "MarketID")]
        public string MarketId { get; set; }

        [DataMember(Order = 3, Name = "ReportDate")]
        public DateTime ReportDate { get; set; }

        [DataMember(Order = 4, Name = "Symbol")]
        public string Symbol { get; set; }

        [DataMember(Order = 5, Name = "TradingSession")]
        public string TradingSession { get; set; }

        [DataMember(Order = 6, Name = "TradingStatus")]
        public string TradingStatus { get; set; }
    }
}
