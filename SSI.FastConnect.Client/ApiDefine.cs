namespace SSI.FastConnect.Client
{
    public struct ApiDefine
    {
        public const string FastConnectUrl = "FastConnectUrl";
        public const string GetCashAcctBal = "Trading/GetCashAcctBal";
        public const string GetMaxSellQty = "Trading/GetMaxSellQty";
        public const string GetMaxBuyQty = "Trading/GetMaxBuyQty";
        public const string GetStockPosition = "Trading/GetStockPosition";
        public const string GetDerivPosition = "Trading/GetDerivPosition";
        public const string GetOrderHistory = "Trading/GetOrderHistory";
        public const string CancelOrder = "Trading/CancelOrder";
        public const string ModifyOrder = "Trading/ModifyOrder";
        public const string NewOrder = "Trading/NewOrder";
        public const string Login = "Trading/Login";
        public const string GetSecuritiesDetail = "Market/GetSecuritiesDetails";
        public const string GetDailyIndex = "Market/GetDailyIndex";
        public const string GetSecuritiesList = "Market/GetSecuritiesList";
        public const string GetDerivAcctBal = "Trading/GetDerivAcctBal";
        public const string GetIntradayOhlc = "Market/GetIntradayOHLC";
        public const string GetIndexComponents = "Market/GetIndexComponents";
        public const string GetIndexList = "Market/GetIndexList";
        public const string GetStockPrice = "Market/GetDailyStockPrice";
        public const string IsRunStreamTrading = "IsRunStreamTrading";
        public const string IsRunApiTrading = "IsRunApiTrading";
        public const string IsRunMarketDataStream = "IsRunMarketDataStream";
        public const string IsRunAPIMarketData = "IsRunAPIMarketData";
        public const string SubscribeValue = "SubscribeValue";
        public const string FastConnectPublicKey = "FastConnectPublicKey";
        public const string FastConnectSecret = "FastConnectSecret";
        public const string FastConnectId = "FastConnectId";
        public const string FCStreamTradingUrl = "FCStreamTradingUrl";
        public const string FCTradingUrl = "FCTradingUrl";
        public const string GetDailyOhlc = "Market/GetDailyOHLC";


    }
    public class ApiDefineV2
    {
        public const string AccessToken = "/api/v2/Market/AccessToken";
        public const string GetDailyOhlc = "/api/v2/Market/DailyOHLC";
        public const string GetSecuritiesDetail = "/api/v2/Market/SecuritiesDetails";
        public const string GetDailyIndex = "/api/v2/Market/DailyIndex";
        public const string GetSecuritiesList = "/api/v2/Market/Securities";
        public const string GetIntradayOhlc = "/api/v2/Market/IntradayOHLC";
        public const string GetIndexComponents = "/api/v2/Market/IndexComponents";
        public const string GetIndexList = "/api/v2/Market/IndexList";
        public const string GetDailyStockPrice = "/api/v2/Market/DailyStockPrice";
    }



}
