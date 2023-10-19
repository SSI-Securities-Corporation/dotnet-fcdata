using SSI.FastConnect.DataContracts.Enums;
using System.Runtime.Serialization;

namespace SSI.FastConnect.DataContracts.Market.Request
{
    [DataContract]
    public class SecuritiesListRequest
    {
        [DataMember(Order = 1, Name = "Market")]
        [HelpDescription("HOSE,HNX,UPCOM,DER, or ALL", true)]
        public string Market { get; set; }

        [DataMember(Order = 2, Name = "PageIndex")]
        [HelpDescription("Number of page, start from 1, default 1", false)]
        public int PageIndex { get; set; } = 1;

        [DataMember(Order = 3, Name = "PageSize")]
        [HelpDescription("Size of a page, 10; 20; 50; 100; 1000 Default 10 ", false)]
        public int PageSize { get; set; } = 10;

        public SecuritiesListRequest GetSample()
        {
            return new SecuritiesListRequest
            {
                Market = "SAMPLE"
            };
        }
    }
}