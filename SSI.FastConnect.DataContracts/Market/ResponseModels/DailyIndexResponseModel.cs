using SSI.FastConnect.DataContracts.Enums;
using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace SSI.FastConnect.DataContracts.Market.ResponseModels
{
    [DataContract]
    public class DailyIndexResponseModel
    {
        [DataMember(Order = 1)]
        [HelpDescription("Index ID")]
        public string IndexId { get; set; }

        [DataMember(Order = 2)]
        [HelpDescription("Value of the index")]
        public string IndexValue { get; set; }

        [DataMember(Order = 3)]
        [HelpDescription("Trading Date")]
        public string TradingDate { get; set; }

        [DataMember(Order = 4)]
        [HelpDescription("Time")]
        public string Time { get; set; }

        [DataMember(Order = 5)]
        [HelpDescription("Change of index ")]
        public string Change { get; set; }

        [DataMember(Order = 6)]
        [HelpDescription("Ratio of Change ")]
        public string RatioChange { get; set; }

        [DataMember(Order = 7)]
        [HelpDescription("Tổng số lệnh khớp (cả thông thường và thỏa thuận)")]
        public string TotalTrade { get; set; }

        [DataMember(Order = 8)]
        [HelpDescription("Tổng matched quantity of normal orders")]
        public string TotalMatchVol { get; set; }

        [DataMember(Order = 9)]
        [HelpDescription("Tổng matched value of normal orders")]
        public string TotalMatchVal { get; set; }

        [DataMember(Order = 10)]
        [HelpDescription("Index")]
        public string TypeIndex { get; set; }

        [DataMember(Order = 11)]
        [HelpDescription("Name of Index")]
        public string IndexName { get; set; }

        [DataMember(Order = 12)]
        [HelpDescription("Total number of symbols having price increase")]
        public string Advances { get; set; }

        [DataMember(Order = 13)]
        [HelpDescription("Total number of symbols having price unchange")]
        public string NoChanges { get; set; }

        [DataMember(Order = 14)]
        [HelpDescription("Total number of symbols having price decrease")]
        public string Declines { get; set; }

        [DataMember(Order = 15)]
        [HelpDescription("Total number of symbols having last price = ceiling price")]
        public string Ceilings { get; set; }

        [DataMember(Order = 16)]
        [HelpDescription("Total number of symbols having last price = floor price")]
        public string Floors { get; set; }

        [DataMember(Order = 17)]
        [HelpDescription("Total matched quantity of puthrough orders")]
        public string TotalDealVol { get; set; }

        [DataMember(Order = 18)]
        [HelpDescription("Total matched value of putthrough orders")]
        public string TotalDealVal { get; set; }

        [DataMember(Order = 19)]
        [HelpDescription("Total matched quantity of both normal and putthrough")]
        public string TotalVol { get; set; }

        [DataMember(Order = 20)]
        [HelpDescription("Total matched value of both normal and putthrough")]
        public string TotalVal { get; set; }

        [DataMember(Order = 21)]
        [HelpDescription("TradingSession")]
        public string TradingSession { get; set; }

    }

    public static class EnumExtension
    {
        public static string ToDescriptionString(this Enum val)
        {
            var attributes = (DescriptionAttribute[])val.GetType().GetField(val.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : string.Empty;
        }
    }
}
