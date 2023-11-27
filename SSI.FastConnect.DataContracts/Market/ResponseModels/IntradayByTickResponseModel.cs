using System;
using System.Runtime.Serialization;
using SSI.FastConnect.DataContracts.Enums;

namespace SSI.FastConnect.DataContracts.Market.ResponseModels
{
    //public class IntradayByTickResponseModel
    //{
    //    public string Symbol { get; set; }
    //    public decimal Open { get; set; }
    //    public string TradingDate { get; set; }
    //    public string Time { get; set; }
    //    public decimal High { get; set; }
    //    public decimal Low { get; set; }
    //    public decimal Close { get; set; }
    //    public decimal Volume { get; set; }
    //    public decimal AskPrice1 { get; set; }
    //    public decimal AskPrice2 { get; set; }
    //    public decimal AskPrice3 { get; set; }
    //    public decimal AskPrice4 { get; set; }
    //    public decimal AskPrice5 { get; set; }
    //    public decimal AskPrice6 { get; set; }
    //    public decimal AskPrice7 { get; set; }
    //    public decimal AskPrice8 { get; set; }
    //    public decimal AskPrice9 { get; set; }
    //    public decimal AskPrice10 { get; set; }
    //    public decimal AskVol1 { get; set; }
    //    public decimal AskVol2 { get; set; }
    //    public decimal AskVol3 { get; set; }
    //    public decimal AskVol4 { get; set; }
    //    public decimal AskVol5 { get; set; }
    //    public decimal AskVol6 { get; set; }
    //    public decimal AskVol7 { get; set; }
    //    public decimal AskVol8 { get; set; }
    //    public decimal AskVol9 { get; set; }
    //    public decimal AskVol10 { get; set; }
    //    public decimal BidPrice1 { get; set; }
    //    public decimal BidPrice2 { get; set; }
    //    public decimal BidPrice3 { get; set; }
    //    public decimal BidPrice4 { get; set; }
    //    public decimal BidPrice5 { get; set; }
    //    public decimal BidPrice6 { get; set; }
    //    public decimal BidPrice7 { get; set; }
    //    public decimal BidPrice8 { get; set; }
    //    public decimal BidPrice9 { get; set; }
    //    public decimal BidPrice10 { get; set; }
    //    public decimal BidVol1 { get; set; }
    //    public decimal BidVol2 { get; set; }
    //    public decimal BidVol3 { get; set; }
    //    public decimal BidVol4 { get; set; }
    //    public decimal BidVol5 { get; set; }
    //    public decimal BidVol6 { get; set; }
    //    public decimal BidVol7 { get; set; }
    //    public decimal BidVol8 { get; set; }
    //    public decimal BidVol9 { get; set; }
    //    public decimal BidVol10 { get; set; }
    //    public string side { get; set; }
    //    public decimal priceChange { get; set; }
    //    public decimal priceChangePercent { get; set; }
    //    public string changeType { get; set; }
    //}
    [DataContract]
    public class IntradayByTickResponseModel
    {
        [DataMember(Order = 1, Name = "Symbol")]
        public string Symbol { get; set; }
        [DataMember(Order = 2, Name = "Open")]
        public decimal Open { get; set; }
        [DataMember(Order = 3, Name = "TradingDate")]
        public string TradingDate { get; set; }
        [DataMember(Order = 4, Name = "Time")]
        public string Time { get; set; }
        [DataMember(Order = 5, Name = "High")]
        public decimal High { get; set; }
        [DataMember(Order = 6, Name = "Low")]
        public decimal Low { get; set; }
        [DataMember(Order = 7, Name = "Close")]
        public decimal Close { get; set; }
        [DataMember(Order = 8, Name = "Volume")]
        public decimal Volume { get; set; }
        [DataMember(Order = 9, Name = "AskPrice1")]
        public decimal AskPrice1 { get; set; }
        [DataMember(Order = 10, Name = "AskPrice2")]
        public decimal AskPrice2 { get; set; }
        [DataMember(Order = 11, Name = "AskPrice3")]
        public decimal AskPrice3 { get; set; }
        [DataMember(Order = 12, Name = "AskPrice4")]
        public decimal AskPrice4 { get; set; }
        [DataMember(Order = 13, Name = "AskPrice5")]
        public decimal AskPrice5 { get; set; }
        [DataMember(Order = 14, Name = "AskPrice6")]
        public decimal AskPrice6 { get; set; }
        [DataMember(Order = 15, Name = "AskPrice7")]
        public decimal AskPrice7 { get; set; }
        [DataMember(Order = 16, Name = "AskPrice8")]
        public decimal AskPrice8 { get; set; }
        [DataMember(Order = 17, Name = "AskPrice9")]
        public decimal AskPrice9 { get; set; }
        [DataMember(Order = 18, Name = "AskPrice10")]
        public decimal AskPrice10 { get; set; }
        [DataMember(Order = 19, Name = "AskVol1")]
        public decimal AskVol1 { get; set; }
        [DataMember(Order = 20, Name = "AskVol2")]
        public decimal AskVol2 { get; set; }
        [DataMember(Order = 21, Name = "AskVol3")]
        public decimal AskVol3 { get; set; }
        [DataMember(Order = 22, Name = "AskVol4")]
        public decimal AskVol4 { get; set; }
        [DataMember(Order = 23, Name = "AskVol5")]
        public decimal AskVol5 { get; set; }
        [DataMember(Order = 24, Name = "AskVol6")]
        public decimal AskVol6 { get; set; }
        [DataMember(Order = 25, Name = "AskVol7")]
        public decimal AskVol7 { get; set; }
        [DataMember(Order = 26, Name = "AskVol8")]
        public decimal AskVol8 { get; set; }
        [DataMember(Order = 27, Name = "AskVol9")]
        public decimal AskVol9 { get; set; }
        [DataMember(Order = 28, Name = "AskVol10")]
        public decimal AskVol10 { get; set; }
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
        [DataMember(Order = 39, Name = "BidVol1")]
        public decimal BidVol1 { get; set; }
        [DataMember(Order = 40, Name = "BidVol2")]
        public decimal BidVol2 { get; set; }
        [DataMember(Order = 41, Name = "BidVol3")]
        public decimal BidVol3 { get; set; }
        [DataMember(Order = 42, Name = "BidVol4")]
        public decimal BidVol4 { get; set; }
        [DataMember(Order = 43, Name = "BidVol5")]
        public decimal BidVol5 { get; set; }
        [DataMember(Order = 44, Name = "BidVol6")]
        public decimal BidVol6 { get; set; }
        [DataMember(Order = 45, Name = "BidVol7")]
        public decimal BidVol7 { get; set; }
        [DataMember(Order = 46, Name = "BidVol8")]
        public decimal BidVol8 { get; set; }
        [DataMember(Order = 47, Name = "BidVol9")]
        public decimal BidVol9 { get; set; }
        [DataMember(Order = 48, Name = "BidVol10")]
        public decimal BidVol10 { get; set; }
        [DataMember(Order = 49, Name = "side")]
        public string side { get; set; }
        [DataMember(Order = 50, Name = "priceChange")]
        public decimal priceChange { get; set; }
        [DataMember(Order = 51, Name = "priceChangePercent")]
        public decimal priceChangePercent { get; set; }
        [DataMember(Order = 52, Name = "changeType")]
        public string changeType { get; set; }
    }
}
