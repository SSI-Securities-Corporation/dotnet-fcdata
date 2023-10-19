using System.Runtime.Serialization;
using SSI.FastConnect.DataContracts.Enums;

namespace SSI.FastConnect.DataContracts.Market.Request
{
    [DataContract]
    public class IndexComponentRequest
    {
        [DataMember(Order = 1, Name = "IndexCode")]
        [HelpDescription("Input Index Code to get consituent stocks", true)]
        public string IndexCode { get; set; }

        [DataMember(Order = 2, Name = "PageIndex")]
        [HelpDescription("Number of page, start from 1, default 1", false)]
        public int PageIndex { get; set; } = 1;
        [DataMember(Order = 3, Name = "PageSize")]
        [HelpDescription("Size of a page, 10; 20; 50; 100; 1000 Default 10 ", false)]
        public int PageSize { get; set; } = 1000;

        public IndexComponentRequest GetSample()
        {
            return new IndexComponentRequest
            {
                IndexCode = "SAMPLE",
                PageSize = 100,
                PageIndex = 10
            };
        }
    }
}
