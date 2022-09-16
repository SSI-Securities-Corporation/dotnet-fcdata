
using System;
using System.Collections.Generic;

namespace SSI.FastConnect.Client
{
    public enum TemplateKey
    {
        ACCESS_TOKEN,
        SECURITIES_LIST,
        SECURITIES_DETAILS,
        INDEX_COMPONENT,
        INDEX_LIST,
        DAILY_OHLC,
        INTRADAY_OHLC,
        DAILY_INDEX,
        DAILY_STOCK_PRICE,
        CLIENT,

        NEWORDER,
        MODIFYORDER,
        CANCELORDER,
        DERPOSITION,
        STOCKPOSITION,
        MAXBUYQTY,
        MAXSELLQTY,
        ACCOUNTBALANCE,
        DERACCOUNTBALANCE,
        ORDERHISTORIES,
    }

    public class TestKey : Attribute
    {
        public int Key { get; set; }
        public TestKey(int key)
        {
            Key = key;
        }
    }

    public class TemplateMapper
    {
        public static Dictionary<string, TemplateKey> DotNetTemplateMapperDic { get; private set; } = new Dictionary<string, TemplateKey>
        {
            {"api/v2/Trading/AccessToken",TemplateKey.ACCESS_TOKEN},
            {"api/v2/Market/GetSecuritiesList" ,TemplateKey.SECURITIES_LIST},
            {"api/v2/Market/GetSecuritiesDetails" ,TemplateKey.SECURITIES_DETAILS},
            {"api/v2/Market/GetIndexComponents" ,TemplateKey.INDEX_COMPONENT},
            {"api/v2/Market/GetIndexList" ,TemplateKey.INDEX_LIST},
            {"api/v2/Market/GetDailyOHLC" ,TemplateKey.DAILY_OHLC},
            {"api/v2/Market/GetIntradayOHLC",TemplateKey.INTRADAY_OHLC},
            {"api/v2/Market/GetDailyIndex",TemplateKey.DAILY_INDEX},
            {"api/v2/Market/GetDailyStockPrice",TemplateKey.DAILY_STOCK_PRICE},

            {"api/v2/Trading/NewOrder",TemplateKey.NEWORDER},
            {"api/v2/Trading/ModifyOrder",TemplateKey.MODIFYORDER},
            {"api/v2/Trading/CancelOrder",TemplateKey.CANCELORDER},
            {"api/v2/Trading/GetDerivPosition",TemplateKey.DERPOSITION},
            {"api/v2/Trading/GetStockPosition",TemplateKey.STOCKPOSITION},
            {"api/v2/Trading/GetMaxBuyQty",TemplateKey.MAXBUYQTY},
            {"api/v2/Trading/GetMaxSellQty",TemplateKey.MAXSELLQTY},
            {"api/v2/Trading/GetCashAcctBal",TemplateKey.ACCOUNTBALANCE},
            {"api/v2/Trading/GetOrderHistory",TemplateKey.ORDERHISTORIES},
            {"api/v2/Trading/GetDerivAcctBal",TemplateKey.DERACCOUNTBALANCE},
            

        };
    }
}