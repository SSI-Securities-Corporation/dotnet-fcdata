
using System.Collections.Generic;

namespace SSI.FCData.Models.Response
{
    public class SecuritiesDetailsResponse : ResponseBase<SecuritiesDetailsResponseModel>
    {
    }
    public class SecuritiesDetailsResponseModel
    {
        public string RType { get; set; }
        public string ReportDate { get; set; }
        public string TotalNoSym { get; set; }
        public List<RepeatedInfo> RepeatedInfo { get; set; }

    }

    public class RepeatedInfo
    {
        public string Isin { get; set; }
        public string Symbol { get; set; }
        public string SymbolName { get; set; }
        public string SymbolEngName { get; set; }
        public string SecType { get; set; }
        public string MarketId { get; set; }
        public string Exchange { get; set; }
        public string Issuer { get; set; }
        public string LotSize { get; set; }
        public string IssueDate { get; set; }
        public string MaturityDate { get; set; }
        public string FirstTradingDate { get; set; }
        public string LastTradingDate { get; set; }
        public string ContractMultiplier { get; set; }
        public string SettlMethod { get; set; }
        public string Underlying { get; set; }
        public string PutOrCall { get; set; }
        public string ExercisePrice { get; set; }
        public string ExerciseStyle { get; set; }
        public string ExcerciseRatio { get; set; }
        public string ListedShare { get; set; }
        public string TickPrice1 { get; set; }
        public string TickIncrement1 { get; set; }
        public string TickPrice2 { get; set; }
        public string TickIncrement2 { get; set; }
        public string TickPrice3 { get; set; }
        public string TickIncrement3 { get; set; }
        public string TickPrice4 { get; set; }
        public string TickIncrement4 { get; set; }

    }
}
