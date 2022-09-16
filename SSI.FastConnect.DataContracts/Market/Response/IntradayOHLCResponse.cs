using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using SSI.FastConnect.DataContracts.Market.ResponseModels;

namespace SSI.FastConnect.DataContracts.Market.Response
{
    [DataContract]
    public class IntradayOHLCResponse : ResponseBase<IntradayOHLCResponseModel>
    {
        public IntradayOHLCResponse GetSample()
        {
            return new IntradayOHLCResponse
            {
                Data = new List<IntradayOHLCResponseModel>
                {
                    new IntradayOHLCResponseModel
                    {
                        Symbol = "SAMPLE",
                        Open ="1",
                        Close ="1",
                        High ="1",
                        Low ="1",
                        TradingDate = DateTime.Now.ToString("dd/MM/yyyy"),
                        Value ="1",
                        Volume ="1",
                        Time = "11:11:11"
                    }
                }
            };
        }
    }
}
