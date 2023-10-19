using System.Runtime.Serialization;
using SSI.FastConnect.DataContracts.Enums;

namespace SSI.FastConnect.DataContracts.Market.ResponseModels
{
    [DataContract]
    public class IndexListResponseModel
    {
        [DataMember(Order = 1, Name = "IndexCode")]
        [HelpDescription("Index code")]
        public string IndexCode { get; set; }

        [DataMember(Order = 2, Name = "IndexName")]
        [HelpDescription("Index name")]
        public string IndexName { get; set; }

        [DataMember(Order = 3, Name = "Exchange")]
        [HelpDescription("Exchange of the Index")]
        public string Exchange { get; set; }

    }
}
