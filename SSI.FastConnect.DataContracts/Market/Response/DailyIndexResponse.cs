using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using SSI.FastConnect.DataContracts.Enums;
using SSI.FastConnect.DataContracts.Market.ResponseModels;

namespace SSI.FastConnect.DataContracts.Market.Response
{
    [DataContract]
    public class DailyIndexResponse : ResponseBase<DailyIndexResponseModel>
    {
        public DailyIndexResponse GetSample()
        {
            return new DailyIndexResponse
            {
                Data = new List<DailyIndexResponseModel>
                {
                    new DailyIndexResponseModel
                    {
                        TradingDate = DateTime.Now.ToString("dd/MM/yyyy"),
                        IndexName = "SAMPLE",
                        IndexId = "SAMPLE",
                        TotalTrade = "1",
                        TotalMatchVal = "1",
                        TotalMatchVol = "1",
                        RatioChange = "1",
                        IndexValue = "1",
                        Change = "1",
                        Advances = "1",
                        Ceilings = "1",
                        Declines = "1",
                        Floors = "1",
                        NoChanges = "1",
                        TotalDealVol = "1",
                        TotalDealVal = "1",
                        TypeIndex = "SAMPLE",
                        TotalVol = "1",
                        Time = DateTime.Now.ToString("HH:mm:ss"),
                        TotalVal = "1",
                        TradingSession = "ATO"
                    }
                },
                Status = StatusEnum.Success.ToString(),
                TotalRecord = 1,
                Message = StatusEnum.Success.ToDescriptionString()
            };
        }
    }
}
