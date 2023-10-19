using System.Runtime.Serialization;
using SSI.FastConnect.DataContracts.Enums;

namespace SSI.FastConnect.DataContracts.Market.Request
{
    [DataContract]
    public class IntradayOHLCRequest
    {
        [DataMember(Order = 1, Name = "Symbol")]
        [HelpDescription("Input Index ID or Instrument Symbol to get data. Including Stock, Derivatives, CW",true)]
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
        public int PageSize { get; set; } = 10000;

        [DataMember(Order = 6, Name = "Resolution")]
        [HelpDescription("1S, 1P ,5P ,15P ,30P ,1H", false)]
        public int Resolution { get; set; } = 10;

        public IntradayOHLCRequest GetSample()
        {
            return  new IntradayOHLCRequest
            {
                Symbol = "SAMPLE",
                FromDate = "11/11/2019",
                ToDate = "11/12/2019",
                PageIndex = 1,
                PageSize = 100,
                ascending = "true",
            };
        }
        [DataMember(Order = 7, Name = "ascending")]
        public string ascending { get; set; }
    }
}
