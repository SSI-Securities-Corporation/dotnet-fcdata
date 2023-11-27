using System.Runtime.Serialization;
using SSI.FastConnect.DataContracts.Enums;

namespace SSI.FastConnect.DataContracts.Market.Request
{
    [DataContract]
    public class IntradayByTickRequest
    {
        [DataMember(Order = 1, Name = "Symbol")]
        [HelpDescription("Symbol of the security, Include Stock, CW and Derivatives", true)]
        public string Symbol { get; set; }

        [DataMember(Order = 2, Name = "FromDate")]
        [HelpDescription("'DD/MM/YYYY',If not specify get today date", false)]
        public string FromDate { get; set; }

        [DataMember(Order = 3, Name = "ToDate")]
        [HelpDescription("'DD/MM/YYYY',If not specify get today date", false)]
        public string ToDate { get; set; }

        [DataMember(Order = 4, Name = "PageIndex")]
        [HelpDescription("Number of page, start from 1, default 1", false)]
        public int PageIndex { get; set; } = 1;

        [DataMember(Order = 5, Name = "PageSize")]
        [HelpDescription("Size of a page, 10; 20; 50; 100; 1000 Default 10 ", false)]
        public int PageSize { get; set; } = 10;

        public IntradayByTickRequest GetSample()
        {
            return new IntradayByTickRequest
            {
                Symbol = "SAMPLE",
                FromDate = "11/11/2019",
                ToDate = "11/12/2019",
                PageIndex = 1,
                PageSize = 100
            };
        }
    }
}
