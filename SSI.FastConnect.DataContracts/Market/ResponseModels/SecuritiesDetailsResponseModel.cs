using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using SSI.FastConnect.DataContracts.Enums;

namespace SSI.FastConnect.DataContracts.Market.ResponseModels
{
    [DataContract]
    public class SecuritiesDetailsResponseModel
    {
        [DataMember(Order = 1, Name = "RType")]
        [HelpDescription("This is a fixed value to identify the value of this record for equity information.Format “y” – Security List")]
        public string RType { get; set; }

        [DataMember(Order = 2, Name = "ReportDate")]
        [HelpDescription("Date & time of the data record.Format dd/MM/yyyy HH:mm:ss")]
        public string ReportDate { get; set; }

        [DataMember(Order = 3, Name = "TotalNoSym")]
        [HelpDescription("Total number of symbol returned")]
        public string TotalNoSym { get; set; }

        [DataMember(Order = 4, Name = "RepeatedInfo")]
        [HelpDescription("Repeated information")]
        public List<RepeatedInfo> RepeatedInfo { get; set; }

    }

    [DataContract]
    public class RepeatedInfo
    {

        [DataMember(Order = 5, Name = "Isin")]
        [HelpDescription("ISIN code of the securities.Not used yet")]
        public string Isin { get; set; }

        [DataMember(Order = 6, Name = "Symbol")]
        [HelpDescription("The local trading code of the equity listed in the exchanges.Format : Equity listed in the exchanges.")]
        public string Symbol { get; set; }

        [DataMember(Order = 7, Name = "SymbolName")]
        [HelpDescription("Name of the securities")]
        public string SymbolName { get; set; }

        [DataMember(Order = 8, Name = "SymbolEngName")]
        [HelpDescription("Name in English")]
        public string SymbolEngName { get; set; }

        [DataMember(Order = 9, Name = "SecType")]
        [HelpDescription("The type of equity." +
                         "ST: Stock; " +
                         "CW: Covered Warrant; " +
                         "FU: Futures; " +
                         "EF: ETF; " +
                         "BO: BOND; " +
                         "OF: OEF; " +
                         "MF: Mutual Fund")]
        public string SecType { get; set; }

        [DataMember(Order = 10, Name = "MarketId")]
        [HelpDescription("The market of the securities.-HOSE; HNX; HNXBOND; UPCOM; DER")]
        public string MarketId { get; set; }

        [DataMember(Order = 11, Name = "Exchange")]
        [HelpDescription("The ID of the corresponding Exchange where the equity is trading." +
                         "HOSE: Hochiminh Stock Exchange , " +
                         "HNX: Hanoi Stock Exchange")]
        public string Exchange { get; set; }

        [DataMember(Order = 12, Name = "Issuer")]
        [HelpDescription("Issuer of the security")]
        public string Issuer { get; set; }

        [DataMember(Order = 13, Name = "LotSize")]
        [HelpDescription("Trading lot size of the security")]
        public string LotSize { get; set; }

        [DataMember(Order = 14, Name = "IssueDate")]
        public string IssueDate { get; set; }

        [DataMember(Order = 15, Name = "MaturityDate")]
        public string MaturityDate { get; set; }

        [DataMember(Order = 16, Name = "FirstTradingDate")]
        public string FirstTradingDate { get; set; }

        [DataMember(Order = 17, Name = "LastTradingDate")]
        public string LastTradingDate { get; set; }

        [DataMember(Order = 18, Name = "ContractMultiplier")]
        [HelpDescription("Contract Multiplier")]
        public string ContractMultiplier { get; set; }

        [DataMember(Order = 19, Name = "SettlMethod")]
        [HelpDescription("Settlement method of the securities. Format : Cash,Physical")]
        public string SettlMethod { get; set; }

        [DataMember(Order = 20, Name = "Underlying")]
        [HelpDescription("Underlying securities")]
        public string Underlying { get; set; }

        [DataMember(Order = 21, Name = "PutOrCall")]
        [HelpDescription("Option type. P : Put, C : Call")]
        public string PutOrCall { get; set; }

        [DataMember(Order = 22, Name = "ExercisePrice")]
        [HelpDescription("Exercise price. Used for Options, CW")]
        public string ExercisePrice { get; set; }

        [DataMember(Order = 23, Name = "ExerciseStyle")]
        [HelpDescription("Exercise Style. Used for CW, Options , CW .  " +
                         "Format : E -> European, A -> American")]
        public string ExerciseStyle { get; set; }

        [DataMember(Order = 24, Name = "ExcerciseRatio")]
        [HelpDescription("Exercise ratio, used for CW, Options")]
        public string ExcerciseRatio { get; set; }

        [DataMember(Order = 25, Name = "ListedShare")]
        [HelpDescription("Number of listed shares ")]
        public string ListedShare { get; set; }

        [DataMember(Order = 26, Name = "TickPrice1")]
        [HelpDescription("Starting price range 1 for tick rule")]
        public string TickPrice1 { get; set; }

        [DataMember(Order = 27, Name = "TickIncrement1")]
        [HelpDescription("Tick increment for price range 1 for tick rule")]
        public string TickIncrement1 { get; set; }

        [DataMember(Order = 28, Name = "TickPrice2")]
        [HelpDescription("Starting price range 2 for tick rule")]
        public string TickPrice2 { get; set; }

        [DataMember(Order = 29, Name = "TickIncrement2")]
        [HelpDescription("Tick increment for price range 2")]
        public string TickIncrement2 { get; set; }

        [DataMember(Order = 30, Name = "TickPrice3")]
        [HelpDescription("Starting price range 3 for tick rule")]
        public string TickPrice3 { get; set; }

        [DataMember(Order = 31, Name = "TickIncrement3")]
        [HelpDescription("Tick increment for price range 3")]
        public string TickIncrement3 { get; set; }

        [DataMember(Order = 32, Name = "TickPrice4")]
        [HelpDescription("Starting price range 4 for tick rule")]
        public string TickPrice4 { get; set; }

        [DataMember(Order = 33, Name = "TickIncrement4")]
        [HelpDescription("Tick increment for price range 4")]
        public string TickIncrement4 { get; set; }
        
    }
}
