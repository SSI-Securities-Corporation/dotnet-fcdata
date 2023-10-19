using System;
using System.Runtime.Serialization;
using SSI.FastConnect.DataContracts.Enums;

namespace SSI.FastConnect.DataContracts.Market.ResponseModels
{
    [DataContract]
    public class DailyOHLCResponseModel
    {
        [DataMember(Order = 1, Name = "Symbol")]
        [HelpDescription("Index ID/Stock Symbol")]
        public string Symbol { get; set; }

        [DataMember(Order = 2, Name = "Market")]
        [HelpDescription("Market of the symbol")]
        public string Market { get; set; }

        [DataMember(Order = 3, Name = "TradingDate")]
        [HelpDescription("Trading Date")]
        public string TradingDate { get; set; }

        [DataMember(Order = 4, Name = "Time")]
        [HelpDescription("Time")]
        public string Time { get; set; }

        [DataMember(Order = 5, Name = "Open")]
        public string Open { get; set; }

        [DataMember(Order = 6, Name = "High")]
        public string High { get; set; }

        [DataMember(Order = 7, Name = "Low")]
        public string Low { get; set; }

        [DataMember(Order = 8, Name = "Close")]
        public string Close { get; set; }

        [DataMember(Order = 9, Name = "Volume")]
        public string Volume { get; set; }

        [DataMember(Order = 10, Name = "Value")]
        public string Value { get; set; }
    }
}
