using System.ComponentModel;

namespace SSI.FastConnect.DataContracts.Enums
{
    public enum StatusEnum
    {
        [Description("Success")]
        Success = 0,

        [Description("There is no data")]
        NoDataFound = 1,

        [Description("Credential is not valid")]
        CredentialIsNotValid = 2,

        [Description("Missing credentials")]
        CredentialsMissing = 3,

        [Description("Cannot get request")]
        CannotGetRequest = 4,

        [Description("Validator is required")]
        MissingValidator = 6,

        [Description("Something wrong happend")]
        Exception = 999,

        [Description("Cannot get random byte key")]
        ByteKeyRequired = 998,

        #region Market
        [Description("Market code is not valid, market : HOSE, HNX, HNXBOND, UPCOM ,DER or (EMPTY)")]
        MarketCodeError = 5,

        [Description("Null or empty symbol")]
        NullOrEmptySymbol = 7,

        [Description("Null or empty index code")]
        IndexCodeError = 8,

        [Description("Date time format dd/MM/yyyy and ('from date' <= 'to date') < now , max range 30 days")]
        DateTimeInvalid = 9,

        [Description("Number or page must start from 1 , default 1")]
        PageIndexInvalid = 10,

        [Description("Size of a page must 10, 20, 50, 100 or 1000, default 10")]
        PageSizeInvalid = 11,

        [Description("Market must HOSE, HNX, UPCOM, DER,or BOND")]
        DailyStockPriceMarketInvalid = 12,

        [Description("Request null or type invalid")]
        RequestInvalid = 13,

        [Description("Market code is not valid, market : HOSE,HNX or (EMPTY)")]
        MarketIndexError = 14,

        [Description("Symbol of stock must define")]
        SymbolInvalid = 15,

        [Description("From date must < to date")]
        FromDateAndToDateInValid = 16,

        [Description("Time span (to date - from date) must <= 30 days")]
        IntradayTimeSpanInvalid = 17,

        [Description("Null or empty index id")]
        IndexIdRequired = 18,

        [Description("Page index must be greated than zero")]
        PageIndexGreaterThanZero = 19,

        [Description("Page size must be greated than zero")]
        PageSizeGreaterThanZero = 20,

   
        #endregion

        #region File
        [Description("Null or empty client path")]
        ClientPathIsRequired = 21,

        [Description("Null or empty client type, type : T or MK ")]
        ClientTypeIsRequired = 22,

        [Description("Pls! Retry after 1 minute")]
        OverloadNumberFileToDownload = 23,
        #endregion

        [Description("Data not ready")]
        DataNotReady = 24,

        [Description("Request is null")]
        RequestNull = 25,

        [Description("PageSize must > 0 & PageSize < 10000")]
        PagesizeWrong = 26,
    }
}
