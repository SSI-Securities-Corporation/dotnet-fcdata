using SSI.FastConnect.DataContracts.Enums;
using System.Runtime.Serialization;

namespace SSI.FastConnect.DataContracts.Market.Request
{
    [DataContract]
    public class DailyIndexRequest
    {
        [DataMember(Order = 1, Name = "RequestId")]
        public string RequestId { get; set; }

        [DataMember(Order = 2, Name = "IndexId")]
        [HelpDescription("Valid values can be queried by api  getIndexList", true)]
        public string IndexId { get; set; }

        [DataMember(Order = 3, Name = "FromDate")]
        [HelpDescription("'DD/MM/YYYY',If not specify get today date", false)]
        public string FromDate { get; set; }

        [DataMember(Order = 4, Name = "ToDate")]
        [HelpDescription("'DD/MM/YYYY',If not specify get today date", false)]
        public string ToDate { get; set; }

        [DataMember(Order = 5, Name = "PageIndex")]
        public int PageIndex { get; set; }

        [DataMember(Order = 6, Name = "PageSize")]
        [HelpDescription("Size of a page, 10; 20; 50; 100; 1000 Default 10 ", false)]
        public int PageSize { get; set; }

        [DataMember(Order = 7, Name = "OrderBy")]
        public string OrderBy { get; set; }

        [DataMember(Order = 8, Name = "Order")]
        public string Order { get; set; }

        public DailyIndexRequest GetSample()
        {
            return new DailyIndexRequest
            {
                PageSize = 100,
                PageIndex = 1,
                IndexId = "SAMPLE",
                ToDate = "11/12/2019",
                FromDate = "11/11/2019",
                Order = "SAMPLE",
                OrderBy = "SAMPLE",
                RequestId = "SAMPLE"
            };
        }
    }
}
