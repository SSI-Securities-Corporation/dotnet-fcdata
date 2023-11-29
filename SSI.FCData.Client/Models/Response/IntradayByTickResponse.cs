
namespace SSI.FCData.Models.Response
{
    public class IntradayByTickResponse : ResponseBase<IntradayByTickResponseModel>
    {
        
    }
    public class IntradayByTickResponseModel
    {
        public string Symbol { get; set; }
        public decimal Open { get; set; }
        public string TradingDate { get; set; }
        public string Time { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal Close { get; set; }
        public decimal Volume { get; set; }
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
        public decimal AskVol1 { get; set; }
        public decimal AskVol2 { get; set; }
        public decimal AskVol3 { get; set; }
        public decimal AskVol4 { get; set; }
        public decimal AskVol5 { get; set; }
        public decimal AskVol6 { get; set; }
        public decimal AskVol7 { get; set; }
        public decimal AskVol8 { get; set; }
        public decimal AskVol9 { get; set; }
        public decimal AskVol10 { get; set; }
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
        public decimal BidVol1 { get; set; }
        public decimal BidVol2 { get; set; }
        public decimal BidVol3 { get; set; }
        public decimal BidVol4 { get; set; }
        public decimal BidVol5 { get; set; }
        public decimal BidVol6 { get; set; }
        public decimal BidVol7 { get; set; }
        public decimal BidVol8 { get; set; }
        public decimal BidVol9 { get; set; }
        public decimal BidVol10 { get; set; }
        public string side { get; set; }
        public decimal priceChange { get; set; }
        public decimal priceChangePercent { get; set; }
        public string changeType { get; set; }
    }

}
