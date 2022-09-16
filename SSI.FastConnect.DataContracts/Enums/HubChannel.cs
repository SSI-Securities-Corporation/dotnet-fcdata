using System.Collections.Generic;

namespace SSI.FastConnect.DataContracts.Enums
{
    public static class HubChannel
    {
        public const string SecuritiesStatus = "F";
        public const string StockPrice = "X";
        public const string ForeignRoom = "R";
        public const string IndexInformation = "MI";
        public const string OhlcInformation = "B";

        public const string Trade = "X-TRADE";
        public const string Quote = "X-QUOTE";

        public const string MdhMaster = "MDM";
        public const string MdhTrade = "MDT";
        public const string MdhQuote = "MDQ";
        public const string MdhInfo = "MDI";
        public const string MdhRoom = "MDR";
        public const string MdLight = "MDL";

        public const string All = "ALL";

        public static List<string> Channels => new List<string>
        {
            All,
            StockPrice,
            ForeignRoom,
            IndexInformation,
            OhlcInformation,
            SecuritiesStatus,
            Trade,
            Quote,
            MdhMaster,
            MdhTrade,
            MdhQuote,
            MdhInfo,
            MdhRoom,
            MdLight
        };
    }
}