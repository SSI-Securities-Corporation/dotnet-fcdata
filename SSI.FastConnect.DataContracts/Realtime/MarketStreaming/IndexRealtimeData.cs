using System.Runtime.Serialization;

namespace SSI.FastConnect.DataContracts.Realtime
{
    [DataContract]
    public class IndexRealtimeData
    {
        [DataMember(Order = 1, Name = "Rtype")]
        public string Rtype { get; set; }

        [DataMember(Order = 2, Name = "IndexID")]
        public string IndexId { get; set; }

        [DataMember(Order = 3, Name = "IndexValue")]
        public  decimal IndexValue { get; set; }

        [DataMember(Order = 4, Name = "TradingDate")]
        public string TradingDate { get; set; }

        [DataMember(Order = 5, Name = "Time")]
        public string Time { get; set; }

        [DataMember(Order = 6, Name = "Change")]
        public decimal Change { get; set; }

        [DataMember(Order = 7, Name = "RatioChange")]
        public decimal RatioChange { get; set; }

        [DataMember(Order = 8, Name = "TotalTrade")]
        public decimal TotalTrade { get; set; }

        [DataMember(Order = 9, Name = "TotalQtty")]
        public decimal TotalQtty { get; set; }

        [DataMember(Order = 10, Name = "TotalValue")]
        public decimal TotalValue { get; set; }

        [DataMember(Order = 11, Name = "TypeIndex")]
        public string TypeIndex { get; set; }

        [DataMember(Order = 12, Name = "IndexName")]
        public string IndexName { get; set; }

        [DataMember(Order = 13, Name = "Advances")]
        public decimal Advances { get; set; }

        [DataMember(Order = 14, Name = "Nochanges")]
        public decimal Nochanges { get; set; }

        [DataMember(Order = 15, Name = "Declines")]
        public decimal Declines { get; set; }

        [DataMember(Order = 16, Name = "Ceiling")]
        public decimal Ceiling { get; set; }

        [DataMember(Order = 17, Name = "Floor")]
        public decimal Floor { get; set; }

        [DataMember(Order = 18, Name = "TotalQttyPt")]
        public decimal TotalQttyPt { get; set; }

        [DataMember(Order = 19, Name = "TotalValuePt")]
        public decimal TotalValuePt { get; set; }

        [DataMember(Order = 20, Name = "AllQty")]
        public decimal AllQty { get; set; }

        [DataMember(Order = 21, Name = "AllValue")]
        public decimal AllValue { get; set; }

        [DataMember(Order = 22, Name = "TradingSession")]
        public string TradingSession { get; set; }

        [DataMember(Order = 23, Name = "Market")]
        public string Market { get; set; }

        [DataMember(Order = 24, Name = "Exchange")]
        public string Exchange { get; set; }
    }
}
