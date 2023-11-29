
namespace SSI.FCData.Models.Streaming
{
    public class IndexRealtimeData
    {
        public string Rtype { get; set; }

        public string IndexId { get; set; }

        public  decimal IndexValue { get; set; }

        public string TradingDate { get; set; }

        public string Time { get; set; }

        public decimal Change { get; set; }

        public decimal RatioChange { get; set; }

        public decimal TotalTrade { get; set; }

        public decimal TotalQtty { get; set; }

        public decimal TotalValue { get; set; }

        public string TypeIndex { get; set; }

        public string IndexName { get; set; }

        public decimal Advances { get; set; }

        public decimal Nochanges { get; set; }

        public decimal Declines { get; set; }

        public decimal Ceiling { get; set; }

        public decimal Floor { get; set; }

        public decimal TotalQttyPt { get; set; }

        public decimal TotalValuePt { get; set; }

        public decimal AllQty { get; set; }

        public decimal AllValue { get; set; }

        public string TradingSession { get; set; }

        public string Market { get; set; }

        public string Exchange { get; set; }
    }
}
