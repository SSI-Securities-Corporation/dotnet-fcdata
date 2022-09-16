using System.Runtime.Serialization;
using SSI.FastConnect.DataContracts.Enums;

namespace SSI.FastConnect.DataContracts.Market.Request
{
    [DataContract]
    public class SecuritiesDetailsRequest
    {
        [DataMember(Order = 1, Name = "Market")]
        [HelpDescription("HOSE,HNX,UPCOM,DER, or ALL", true)]
        public string Market { get; set; }
        [DataMember(Order = 2, Name = "Symbol")]
        public string Symbol { get; set; }
        [DataMember(Order = 3, Name = "PageIndex")]
        [HelpDescription("Number of page, start from 1, default 1", false)]
        public int PageIndex { get; set; } = 1;
        [DataMember(Order = 4, Name = "PageSize")]
        [HelpDescription("Size of a page, 10; 20; 50; 100; 1000 Default 10 ", false)]
        public int PageSize { get; set; } = 10;

        public SecuritiesDetailsRequest GetSample()
        {
            return new SecuritiesDetailsRequest
            {
                Symbol = "SAMPLE",
                Market = "SAMPLE",
                PageSize = 1,
                PageIndex = 100
            };
        }
    }
}
