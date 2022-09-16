using System;
using System.Runtime.Serialization;

namespace SSI.FastConnect.DataContracts.Realtime
{
    [DataContract]
    public class MarketRealtimeData
    {
        [DataMember(Order = 1, Name = "Rtype")]
        public string RType { get; set; }

        [DataMember(Order = 2, Name = "TradingDate")]
        public DateTime TradingDate { get; set; }

        [DataMember(Order = 3, Name = "Time")]
        public string TradingTime { get; set; }

        [DataMember(Order = 4, Name = "ISIN")]
        public string Isin { get; set; }

        [DataMember(Order = 5, Name = "Symbol")]
        public string Symbol { get; set; }

        [DataMember(Order = 6, Name = "Ceiling")]
        public decimal Ceiling { get; set; }

        [DataMember(Order = 7, Name = "Floor")]
        public decimal Floor { get; set; }

        [DataMember(Order = 8, Name = "RefPrice")]
        public decimal RefPrice { get; set; }

        [DataMember(Order = 9, Name = "Open")]
        public decimal Open { get; set; }

        [DataMember(Order = 10, Name = "Close")]
        public decimal Close { get; set; }

        [DataMember(Order = 11, Name = "High")]
        public decimal High { get; set; }

        [DataMember(Order = 12, Name = "Low")]
        public decimal Low { get; set; }

        [DataMember(Order = 13, Name = "Avg")]
        public decimal Avg { get; set; }

        [DataMember(Order = 14, Name = "PriorVal")]
        public decimal PriorVal { get; set; }

        [DataMember(Order = 15, Name = "LastVal")]
        public decimal LastVal { get; set; }

        [DataMember(Order = 16, Name = "LastVol")]
        public decimal LastVol { get; set; }

        [DataMember(Order = 17, Name = "TotalVal")]
        public decimal TotalVal { get; set; }

        [DataMember(Order = 18, Name = "TotalVol")]
        public decimal TotalVol { get; set; }

        [DataMember(Order = 19, Name = "BidVol1")]
        public decimal BidVol1 { get; set; }

        [DataMember(Order = 20, Name = "BidVol2")]
        public decimal BidVol2 { get; set; }

        [DataMember(Order = 21, Name = "BidVol3")]
        public decimal BidVol3 { get; set; }

        [DataMember(Order = 22, Name = "BidVol4")]
        public decimal BidVol4 { get; set; }

        [DataMember(Order = 23, Name = "BidVol5")]
        public decimal BidVol5 { get; set; }

        [DataMember(Order = 24, Name = "BidVol6")]
        public decimal BidVol6 { get; set; }

        [DataMember(Order = 25, Name = "BidVol7")]
        public decimal BidVol7 { get; set; }

        [DataMember(Order = 26, Name = "BidVol8")]
        public decimal BidVol8 { get; set; }

        [DataMember(Order = 27, Name = "BidVol9")]
        public decimal BidVol9 { get; set; }

        [DataMember(Order = 28, Name = "BidVol10")]
        public decimal BidVol10 { get; set; }

        [DataMember(Order = 29, Name = "BidPrice1")]
        public decimal BidPrice1 { get; set; }

        [DataMember(Order = 30, Name = "BidPrice2")]
        public decimal BidPrice2 { get; set; }

        [DataMember(Order = 31, Name = "BidPrice3")]
        public decimal BidPrice3 { get; set; }

        [DataMember(Order = 32, Name = "BidPrice4")]
        public decimal BidPrice4 { get; set; }

        [DataMember(Order = 33, Name = "BidPrice5")]
        public decimal BidPrice5 { get; set; }

        [DataMember(Order = 34, Name = "BidPrice6")]
        public decimal BidPrice6 { get; set; }

        [DataMember(Order = 35, Name = "BidPrice7")]
        public decimal BidPrice7 { get; set; }

        [DataMember(Order = 36, Name = "BidPrice8")]
        public decimal BidPrice8 { get; set; }

        [DataMember(Order = 37, Name = "BidPrice9")]
        public decimal BidPrice9 { get; set; }

        [DataMember(Order = 38, Name = "BidPrice10")]
        public decimal BidPrice10 { get; set; }

        [DataMember(Order = 39, Name = "AskVol1")]
        public decimal AskVol1 { get; set; }

        [DataMember(Order = 40, Name = "AskVol2")]
        public decimal AskVol2 { get; set; }

        [DataMember(Order = 41, Name = "AskVol3")]
        public decimal AskVol3 { get; set; }

        [DataMember(Order = 42, Name = "AskVol4")]
        public decimal AskVol4 { get; set; }

        [DataMember(Order = 43, Name = "AskVol5")]
        public decimal AskVol5 { get; set; }

        [DataMember(Order = 44, Name = "AskVol6")]
        public decimal AskVol6 { get; set; }

        [DataMember(Order = 45, Name = "AskVol7")]
        public decimal AskVol7 { get; set; }

        [DataMember(Order = 46, Name = "AskVol8")]
        public decimal AskVol8 { get; set; }

        [DataMember(Order = 47, Name = "AskVol9")]
        public decimal AskVol9 { get; set; }

        [DataMember(Order = 48, Name = "AskVol10")]
        public decimal AskVol10 { get; set; }

        [DataMember(Order = 49, Name = "AskPrice")]
        public decimal AskPrice { get; set; }

        [DataMember(Order = 50, Name = "AskPrice2")]
        public decimal AskPrice2 { get; set; }

        [DataMember(Order = 51, Name = "AskPrice3")]
        public decimal AskPrice3 { get; set; }

        [DataMember(Order = 52, Name = "AskPrice4")]
        public decimal AskPrice4 { get; set; }

        [DataMember(Order = 53, Name = "AskPrice5")]
        public decimal AskPrice5 { get; set; }

        [DataMember(Order = 54, Name = "AskPrice6")]
        public decimal AskPrice6 { get; set; }

        [DataMember(Order = 55, Name = "AskPrice7")]
        public decimal AskPrice7 { get; set; }

        [DataMember(Order = 56, Name = "AskPrice8")]
        public decimal AskPrice8 { get; set; }

        [DataMember(Order = 57, Name = "AskPrice9")]
        public decimal AskPrice9 { get; set; }

        [DataMember(Order = 58, Name = "AskPrice10")]
        public decimal AskPrice10 { get; set; }
    }
}
