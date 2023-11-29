
namespace SSI.FCData.Models.Response
{
    public class DailyIndexResponse : ResponseBase<DailyIndexResponseModel>
    {
    }
    public class DailyIndexResponseModel
    {
        public string IndexId { get; set; }
        public string IndexValue { get; set; }
        public string TradingDate { get; set; }
        public string Time { get; set; }
        public string Change { get; set; }
        public string RatioChange { get; set; }

        public string TotalTrade { get; set; }

        public string TotalMatchVol { get; set; }

        public string TotalMatchVal { get; set; }

        public string TypeIndex { get; set; }

        public string IndexName { get; set; }

        public string Advances { get; set; }

        public string NoChanges { get; set; }
        public string Declines { get; set; }
        public string Ceilings { get; set; }
        public string Floors { get; set; }
        public string TotalDealVol { get; set; }
        public string TotalDealVal { get; set; }
        public string TotalVol { get; set; }
        public string TotalVal { get; set; }
        public string TradingSession { get; set; }

    }
}
