
namespace SSI.FCData.Models.Response
{
    public class StockPriceResponse : ResponseBase<DailyStockPriceResponseModel>
    {
        
    }
    public class DailyStockPriceResponseModel
    {
        public string TradingDate { get; set; }

        public string PriceChange { get; set; }

        public string PerPriceChange { get; set; }

        public string CeilingPrice { get; set; }

        public string FloorPrice { get; set; }

        public string RefPrice { get; set; }

        public string OpenPrice { get; set; }

        public string HighestPrice { get; set; }

        public string LowestPrice { get; set; }

        public string ClosePrice { get; set; }

        public string AveragePrice { get; set; }

        public string ClosePriceAdjusted { get; set; }

        public string TotalMatchVol { get; set; }

        public string TotalMatchVal { get; set; }

        public string TotalDealVal { get; set; }

        public string TotalDealVol { get; set; }

        public string ForeignBuyVolTotal { get; set; }

        public string ForeignCurrentRoom { get; set; }

        public string ForeignSellVolTotal { get; set; }

        public string ForeignBuyValTotal { get; set; }

        public string ForeignSellValTotal { get; set; }

        public string TotalBuyTrade { get; set; }

        public string TotalBuyTradeVol { get; set; }

        public string TotalSellTrade { get; set; }

        public string TotalSellTradeVol { get; set; }

        public string NetBuySellVol { get; set; }

        public string NetBuySellVal { get; set; }

        public string TotalTradedVol { get; set; }

        public string TotalTradedValue { get; set; }

        public string Symbol { get; set; }

        public string Time { get; set; }
    }

}
