using System.Collections.Generic;
using System.Runtime.Serialization;
using SSI.FastConnect.DataContracts.Enums;

namespace SSI.FastConnect.DataContracts.Market.ResponseModels
{
    [DataContract]
    public class IndexComponentResponseModel
    {
        [DataMember(Order = 1, Name = "IndexCode")]
        [HelpDescription("Index Code")]
        public string IndexCode { get; set; }

        [DataMember(Order = 2, Name = "IndexName")]
        public string IndexName { get; set; }

        [DataMember(Order = 3, Name = "Exchange")]
        [HelpDescription("Exchange of the Index")]
        public string Exchange { get; set; }

        [DataMember(Order = 4, Name = "TotalSymbolNo")]
        [HelpDescription("Total number of symbols in the Index")]
        public string TotalSymbolNo { get; set; }

        [DataMember(Order = 5, Name = "IndexComponent")]
        public List<IndexComponent> IndexComponent { get; set; }
    }

    [DataContract]
    public class IndexComponent
    {
        [DataMember(Order = 5, Name = "Isin")]
        [HelpDescription("ISIN Code of the security")]
        public string Isin { get; set; }

        [DataMember(Order = 6, Name = "StockSymbol")]
        [HelpDescription("Ticker code of the security")]
        public string StockSymbol { get; set; }
    }
}
