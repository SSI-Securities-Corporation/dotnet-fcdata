using System.Runtime.Serialization;
using SSI.FastConnect.DataContracts.Enums;

namespace SSI.FastConnect.DataContracts.Market.Request
{
    [DataContract]
    public class IndexListRequest
    {
        [DataMember(Order = 1, Name = "Exchange")]
        [HelpDescription("Input Exchange code to get the list of indexes for that Exchange," +
                         "HOSE: HCM Exchange, HNX: Hanoi Exchange." +
                         "If not specify then returns all exchanges", true)]
        public string Exchange { get; set; }
        [DataMember(Order = 2, Name = "PageIndex")]
        [HelpDescription("Number of page, start from 1, default 1", false)]
        public int PageIndex { get; set; } = 1;
        [DataMember(Order = 3, Name = "PageSize")]
        [HelpDescription("Size of a page, 10; 20; 50; 100; 1000 Default 10 ", false)]
        public int PageSize { get; set; } = 10;
        public IndexListRequest GetSample()
        {
            return new IndexListRequest
            {
                Exchange = "HNX"
            };
        }
    }
}
