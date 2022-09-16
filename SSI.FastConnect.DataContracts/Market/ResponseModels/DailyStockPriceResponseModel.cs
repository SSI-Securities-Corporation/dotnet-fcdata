using System;
using System.Runtime.Serialization;
using SSI.FastConnect.DataContracts.Enums;

namespace SSI.FastConnect.DataContracts.Market.ResponseModels
{
    [DataContract]
    public class DailyStockPriceResponseModel
    {
        [DataMember(Order = 1, Name = "TradingDate")]
        [HelpDescription("Index ID/Stock Symbol")]
        public string TradingDate { get; set; }

        [DataMember(Order = 2, Name = "PriceChange")]
        [HelpDescription("Price change")]
        public string PriceChange { get; set; }

        [DataMember(Order = 3, Name = "PerPriceChange")]
        [HelpDescription("Per price change")]
        public string PerPriceChange { get; set; }

        [DataMember(Order = 4, Name = "CeilingPrice")]
        [HelpDescription("Ceiling price")]
        public string CeilingPrice { get; set; }

        [DataMember(Order = 5, Name = "FloorPrice")]
        [HelpDescription("Floor price")]
        public string FloorPrice { get; set; }

        [DataMember(Order = 6, Name = "RefPrice")]
        [HelpDescription("Reference price")]
        public string RefPrice { get; set; }

        [DataMember(Order = 7, Name = "OpenPrice")]
        [HelpDescription("Open price")]
        public string OpenPrice { get; set; }

        [DataMember(Order = 8, Name = "HighestPrice")]
        [HelpDescription("Highest price")]
        public string HighestPrice { get; set; }

        [DataMember(Order = 9, Name = "LowestPrice")]
        [HelpDescription("Lowest price")]
        public string LowestPrice { get; set; }

        [DataMember(Order = 10, Name = "ClosePrice")]
        [HelpDescription("Close price")]
        public string ClosePrice { get; set; }

        [DataMember(Order = 11, Name = "AveragePrice")]
        [HelpDescription("Average price")]
        public string AveragePrice { get; set; }

        [DataMember(Order = 12, Name = "ClosePriceAdjusted")]
        [HelpDescription("Close price adjusted")]
        public string ClosePriceAdjusted { get; set; }

        [DataMember(Order = 13, Name = "TotalMatchVol")]
        [HelpDescription("Total match volume")]
        public string TotalMatchVol { get; set; }

        [DataMember(Order = 14, Name = "TotalMatchVal")]
        [HelpDescription("Total match value")]
        public string TotalMatchVal { get; set; }

        [DataMember(Order = 15, Name = "TotalDealVal")]
        [HelpDescription("Total deal value")]
        public string TotalDealVal { get; set; }

        [DataMember(Order = 16, Name = "TotalDealVol")]
        [HelpDescription("Total deal volume")]
        public string TotalDealVol { get; set; }

        [DataMember(Order = 17, Name = "ForeignBuyVolTotal")]
        [HelpDescription("Total foreign buy volume")]
        public string ForeignBuyVolTotal { get; set; }

        [DataMember(Order = 18, Name = "ForeignCurrentRoom")]
        public string ForeignCurrentRoom { get; set; }

        [DataMember(Order = 19, Name = "ForeignSellVolTotal")]
        [HelpDescription("Total foreign sell volume")]
        public string ForeignSellVolTotal { get; set; }

        [DataMember(Order = 20, Name = "ForeignBuyValTotal")]
        [HelpDescription("Total foreign buy value")]
        public string ForeignBuyValTotal { get; set; }

        [DataMember(Order = 21, Name = "ForeignSellValTotal")]
        [HelpDescription("Total foreign sell value")]
        public string ForeignSellValTotal { get; set; }

        [DataMember(Order = 22, Name = "TotalBuyTrade")]
        [HelpDescription("Total buy trade")]
        public string TotalBuyTrade { get; set; }

        [DataMember(Order = 23, Name = "TotalBuyTradeVol")]
        [HelpDescription("Total buy trade volume")]
        public string TotalBuyTradeVol { get; set; }

        [DataMember(Order = 24, Name = "TotalSellTrade")]
        [HelpDescription("Total sell trade")]
        public string TotalSellTrade { get; set; }

        [DataMember(Order = 25, Name = "TotalSellTradeVol")]
        [HelpDescription("Total sell trade volume")]
        public string TotalSellTradeVol { get; set; }

        [DataMember(Order = 26, Name = "NetBuySellVol")]
        [HelpDescription("Net volume after netoff from Sell volume from Buy volume")]
        public string NetForeignVol { get; set; }

        [DataMember(Order = 27, Name = "NetBuySellVal")]
        [HelpDescription("Net value after netoff from Sell value from Buy value")]
        public string NetForeignVal { get; set; }

        [DataMember(Order = 28, Name = "TotalTradedVol")]
        [HelpDescription("Total traded vol includes: matched, put and odd")]
        public string TotalTradedVol { get; set; }

        [DataMember(Order = 29, Name = "TotalTradedValue")]
        [HelpDescription("Total traded value includes: matched, put and odd")]
        public string TotalTradedValue { get; set; }

        [DataMember(Order = 30, Name = "Symbol")]
        [HelpDescription("Symbol")]
        public string Symbol { get; set; }

        [DataMember(Order = 31, Name = "Time")]
        [HelpDescription("Time")]
        public string Time { get; set; }

        public DailyStockPriceResponseModel GetSample()
        {
            return new DailyStockPriceResponseModel
            {
                TradingDate = DateTime.Now.ToString("dd/MM/yyyy"),
                PriceChange = "1",
                FloorPrice = "1",
                ForeignBuyVolTotal = "1",
                AveragePrice = "1",
                ClosePriceAdjusted = "1",
                TotalTradedVol = "1",
                ForeignSellVolTotal = "1",
                TotalSellTradeVol = "1",
                HighestPrice = "1",
                ClosePrice = "1",
                CeilingPrice = "1",
                LowestPrice = "1",
                PerPriceChange = "1",
                OpenPrice = "1",
                ForeignBuyValTotal = "1",
                NetForeignVal = "1",
                TotalSellTrade = "1",
                ForeignSellValTotal = "1",
                TotalTradedValue = "1",
                TotalBuyTradeVol = "1",
                TotalMatchVal = "1",
                TotalBuyTrade = "1",
                TotalMatchVol = "1",
                NetForeignVol = "1",
                RefPrice = "1",
                TotalDealVal = "1",
                ForeignCurrentRoom = "1",
                TotalDealVol = "1",
                Symbol = "SSI",
                Time = "10:00:00"
            };
        }
    }
}
