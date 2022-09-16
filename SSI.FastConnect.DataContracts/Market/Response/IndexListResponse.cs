using System.Collections.Generic;
using System.Runtime.Serialization;
using SSI.FastConnect.DataContracts.Market.ResponseModels;

namespace SSI.FastConnect.DataContracts.Market.Response
{
    [DataContract]
    public class IndexListResponse : ResponseBase<IndexListResponseModel>
    {
        public IndexListResponse GetSample()
        {
            return new IndexListResponse
            {
                Data = new List<IndexListResponseModel>
                {
                    new IndexListResponseModel
                    {
                        IndexCode = "SAMPLE",
                        Exchange = "SAMPLE",
                        IndexName = "SAMPLE"
                    }
                }
            };
        }
    }
}
