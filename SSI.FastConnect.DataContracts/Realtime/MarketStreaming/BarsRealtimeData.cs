using System;
using System.Runtime.Serialization;

namespace SSI.FastConnect.DataContracts.Realtime
{
    [DataContract]
    public class BarsRealtimeData
    {
        [DataMember(Order = 1, Name = "Rtype")]
        public string Rtype { get; set; }

        [DataMember(Order = 2, Name = "Time")]
        public string Time { get; set; }

        [DataMember(Order = 3, Name = "Symbol")]
        public string Symbol { get; set; }

        [DataMember(Order = 4, Name = "Open")]
        public decimal Open { get; set; }

        [DataMember(Order = 5, Name = "High")]
        public decimal High { get; set; }

        [DataMember(Order = 6, Name = "Low")]
        public decimal Low { get; set; }

        [DataMember(Order = 7, Name = "Close")]
        public decimal Close { get; set; }

        [DataMember(Order = 8, Name = "Volume")]
        public decimal Volume { get; set; }

        [DataMember(Order = 9, Name = "Value")]
        public decimal Value { get; set; }
    }
}
