using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using SSI.FastConnect.DataContracts.Market.ResponseModels;

namespace SSI.FastConnect.DataContracts.Market.Response
{
    [DataContract]
    public class DailyOhlcResponse : ResponseBase<DailyOHLCResponseModel>
    {
        public DailyOhlcResponse GetSample()
        {
            return new DailyOhlcResponse
            {
                Data = new List<DailyOHLCResponseModel>
                {
                    new DailyOHLCResponseModel
                    {
                        Symbol = "SAMPLE",
                        Market = "SAMPLE",
                        TradingDate = DateTime.Now.ToString("dd/MM/yyyy"),
                        Open = "1",
                        Close = "1",
                        High = "1",
                        Low = "1",
                        Value = "1",
                        Volume = "1"
                    }
                },
                Message = "SUCCESS",
                Status = "SUCCESS",
                TotalRecord = 1
            };
        }
    }
}
