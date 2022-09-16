using SSI.FastConnect.DataContracts.Realtime;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SSI.FastConnect.DataContracts.Market.ResponseModels
{
    [DataContract]
    public class BackTestResponseModel
    {
        [DataMember(Order = 1)]
        public List<MdhfData> Items { get; set; }
    }

    [Serializable]
    public class TradeModel
    {
        public string StockType { get; set; }
        public DateTime TradingDate { get; set; }
        public string TradingTime { get; set; }
        public string Exchange { get; set; }
        public string ConfirmNo { get; set; }
        public string StockNo { get; set; }
        public string StockSymbol { get; set; }
        public decimal MatchedVol { get; set; }
        public decimal Price { get; set; }
        public string Side { get; set; }
        public decimal AccumulatedVol { get; set; }
        public string AccumulatedVal { get; set; }
        public decimal Highest { get; set; }
        public decimal Lowest { get; set; }
        public decimal PriorPrice { get; set; }
        public decimal AvgPrice { get; set; }
        public decimal OpenPrice { get; set; }
        public decimal ClosePrice { get; set; }
        public decimal RemainRoom { get; set; }
    }

    [Serializable]
    public class QuoteModel
    {
        public decimal AskPrice1 { get; set; }
        public decimal AskPrice2 { get; set; }
        public decimal AskPrice3 { get; set; }
        public decimal AskPrice4 { get; set; }
        public decimal AskPrice5 { get; set; }
        public decimal AskPrice6 { get; set; }
        public decimal AskPrice7 { get; set; }
        public decimal AskPrice8 { get; set; }
        public decimal AskPrice9 { get; set; }
        public decimal AskPrice10 { get; set; }
        public string AskVol1 { get; set; }
        public string AskVol2 { get; set; }
        public string AskVol3 { get; set; }
        public string AskVol4 { get; set; }
        public string AskVol5 { get; set; }
        public string AskVol6 { get; set; }
        public string AskVol7 { get; set; }
        public string AskVol8 { get; set; }
        public string AskVol9 { get; set; }
        public string AskVol10 { get; set; }
        public decimal BidPrice1 { get; set; }
        public decimal BidPrice2 { get; set; }
        public decimal BidPrice3 { get; set; }
        public decimal BidPrice4 { get; set; }
        public decimal BidPrice5 { get; set; }
        public decimal BidPrice6 { get; set; }
        public decimal BidPrice7 { get; set; }
        public decimal BidPrice8 { get; set; }
        public decimal BidPrice9 { get; set; }
        public decimal BidPrice10 { get; set; }
        public string BidVol1 { get; set; }
        public string BidVol2 { get; set; }
        public string BidVol3 { get; set; }
        public string BidVol4 { get; set; }
        public string BidVol5 { get; set; }
        public string BidVol6 { get; set; }
        public string BidVol7 { get; set; }
        public string BidVol8 { get; set; }
        public string BidVol9 { get; set; }
        public string BidVol10 { get; set; }
        public string Exchange { get; set; }
        public string StockType { get; set; }
        public string Symbol { get; set; }
        public DateTime TradingDate { get; set; }
        public string TradingTime { get; set; }
    }
}
