using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using SSI.FastConnect.DataContracts.Market.ResponseModels;

namespace SSI.FastConnect.DataContracts.Market.Response
{
    [DataContract]
    public class IntradayByTickResponse : ResponseBase<IntradayByTickResponseModel>
    {
        //public IntradayByTickResponse GetSample()
        //{
        //    return new IntradayByTickResponse
        //    {
        //        Data = new List<IntradayByTickResponseModel>
        //        {
        //            new DailyStockPriceResponseModel
        //            {
        //                TradingDate =DateTime.Now.ToString("dd/MM/yyyy"),
        //                AveragePrice = "1",
        //                CeilingPrice = "1",
        //                ClosePrice = "1",
        //                ClosePriceAdjusted = "1",
        //                FloorPrice = "1",
        //                ForeignBuyValTotal = "1",
        //                ForeignBuyVolTotal = "1",
        //                ForeignCurrentRoom = "1",
        //                ForeignSellValTotal = "1",
        //                ForeignSellVolTotal = "1",
        //                HighestPrice = "1",
        //                LowestPrice = "1",
        //                NetForeignVal = "1",
        //                NetForeignVol = "1",
        //                OpenPrice = "1",
        //                PerPriceChange = "1",
        //                PriceChange = "1",
        //                RefPrice = "1",
        //                TotalBuyTrade = "1",
        //                TotalBuyTradeVol = "1",
        //                TotalDealVal = "1",
        //                TotalDealVol = "1",
        //                TotalMatchVal = "1",
        //                TotalMatchVol = "1",
        //                TotalSellTrade = "1",
        //                TotalSellTradeVol = "1",
        //                TotalTradedValue = "1",
        //                TotalTradedVol ="1",
        //                Symbol = "SSI",
        //                Time = "10:00:00"
        //            }
        //        },
        //        Status = "SUCCESS",
        //        TotalRecord = 1,
        //        Message = "SUCCESS"
        //    };
        //}
    }
}
