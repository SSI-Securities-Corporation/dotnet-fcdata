using System.Collections.Generic;
using SSI.FastConnect.DataContracts.Market.ResponseModels;
using System.Runtime.Serialization;

namespace SSI.FastConnect.DataContracts.Market.Response
{
    [DataContract]
    public class IndexComponentResponse : ResponseBase<IndexComponentResponseModel>
    {
        public IndexComponentResponse GetSample()
        {
            return new IndexComponentResponse
            {
                Data = new List<IndexComponentResponseModel>
                {
                    new IndexComponentResponseModel
                    {
                        Exchange = "SAMPLE",
                        IndexCode = "SAMPLE",
                        IndexName = "SAMPLE",
                        IndexComponent = new List<IndexComponent>
                        {
                            new IndexComponent
                            {
                                Isin = "SAMPLE",
                                StockSymbol = "SAMPLE",
                            }
                        },
                        TotalSymbolNo = "1"
                    }
                }
            };
        }
    }
}
