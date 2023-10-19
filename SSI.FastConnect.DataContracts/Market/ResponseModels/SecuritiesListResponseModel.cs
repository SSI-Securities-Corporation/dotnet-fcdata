using System.Runtime.Serialization;
using SSI.FastConnect.DataContracts.Enums;

namespace SSI.FastConnect.DataContracts.Market.ResponseModels
{
    [DataContract]
    public class SecuritiesListResponseModel
    {
        [DataMember(Order = 1, Name = "Market")]
        public string Market { get; set; } 

        [DataMember(Order = 2, Name = "Symbol")]
        [HelpDescription("Ticker of the securities")]
        public string Symbol { get; set; }

        [DataMember(Order = 3, Name = "StockName")]
        [HelpDescription("Stock Name in Vietnamese ")]
        public string StockName { get; set; }

        [DataMember(Order = 4, Name = "StockEnName")]
        [HelpDescription("Stock Name in English")]
        public string StockEnName { get; set; }

        public SecuritiesListResponseModel GetSample()
        {
            return new SecuritiesListResponseModel
            {
                Symbol = "SAMPLE",
                Market = "SAMPLE",
                StockEnName = "SAMPLE",
                StockName = "SAMPLE"
            };
        }
    }
}
