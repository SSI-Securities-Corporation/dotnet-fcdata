using System;
using System.Runtime.Serialization;

namespace SSI.FastConnect.DataContracts.Realtime
{
    [DataContract]
    public class ForeignRoomRealtimeData
    {
        [DataMember(Order = 1, Name = "Rtype")]
        public string Rtype { get; set; }

        [DataMember(Order = 2, Name = "TradingDate")]
        public DateTime TradingDate { get; set; }

        [DataMember(Order = 3, Name = "Time")]
        public string TradingTime { get; set; }

        [DataMember(Order = 4, Name = "ISIN")]
        public string Isin { get; set; }

        [DataMember(Order = 5, Name = "Symbol")]
        public string Symbol { get; set; }

        [DataMember(Order = 6, Name = "TotalRoom")]
        public decimal TotalRoom { get; set; }

        [DataMember(Order = 7, Name = "CurrentRoom")]
        public decimal CurrentRoom { get; set; }

        [DataMember(Order = 8, Name = "FBuyVol")]
        public decimal FBuyVol { get; set; }

        [DataMember(Order = 9, Name = "FSellVol")]
        public decimal FSellVol { get; set; }

        [DataMember(Order = 10, Name = "FBuyVal")]
        public decimal FBuyVal { get; set; }

        [DataMember(Order = 11, Name = "FSellVal")]
        public decimal FSellVal { get; set; }
    }
}
