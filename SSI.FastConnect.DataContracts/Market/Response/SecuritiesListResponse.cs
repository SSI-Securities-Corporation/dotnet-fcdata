using System.Collections.Generic;
using System.Runtime.Serialization;
using SSI.FastConnect.DataContracts.Enums;
using SSI.FastConnect.DataContracts.Market.ResponseModels;

namespace SSI.FastConnect.DataContracts.Market.Response
{
    [DataContract]
    public class SecuritiesListResponse : ResponseBase<SecuritiesListResponseModel>
    {
        public SecuritiesListResponse GetSample()
        {
            return new SecuritiesListResponse
            {
                Data = new List<SecuritiesListResponseModel>
                {
                    new SecuritiesListResponseModel
                    {
                        Market = "HOSE",
                        Symbol = "SSI",
                        StockEnName = "StockName En",
                        StockName = "StockName VN"
                    },
                    new SecuritiesListResponseModel
                    {
                        Market = "HOSE",
                        Symbol = "SSC",
                        StockEnName = "StockName En",
                        StockName = "StockName VN"
                    },
                },
                Message = StatusEnum.Success.ToDescriptionString(),
                Status = StatusEnum.Success.ToString(),
                TotalRecord = 2
            };
        }
    }
}
