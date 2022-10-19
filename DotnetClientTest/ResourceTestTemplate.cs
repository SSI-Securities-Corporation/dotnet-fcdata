//using Newtonsoft.Json;
//using SSI.FastConnect.DataContracts.Market.Request;
//using SSI.FastConnect.DataContracts.Market.Response;
//using System;
//using System.Collections.Generic;
//using System.Configuration;
//using SSI.FastConnect.Client;

//namespace DotnetFastConnectClientTest
//{
//    public class ResourceTestTemplate
//    {
//        [TestKey((int)TemplateKey.CLIENT)] private static readonly FastConnectClient FastConnectFastConnectClient = new FastConnectClient
//        (
//            apiUrl: "http://192.168.216.137:1188/",
//            conId: ConfigurationManager.AppSettings["FastConnectId"],
//            conSecret: ConfigurationManager.AppSettings["FastConnectSecret"],
//            pubKey: ConfigurationManager.AppSettings["FastConnectPublicKey"]
//        );

//        [TestKey((int)TemplateKey.SECURITIES_LIST)]
//        public static async void TestSecuritiesList(FastConnectClient FastConnectClient)
//        {
//            var req = new SecuritiesListRequest()
//            {
//                Market = "HOSE"
//            };
//            var x = await FastConnectFastConnectClient.Get<SecuritiesListRequest, SecuritiesListResponse>(
//                req, apiPath: ApiDefine.GetSecuritiesList);
//            Console.WriteLine(JsonConvert.SerializeObject(x.DeserializeObj));
//        }

//        [TestKey((int)TemplateKey.SECURITIES_DETAILS)]
//        public static async void TestSecuritiesDetail(FastConnectClient FastConnectClient)
//        {
//            var req = new SecuritiesDetailsRequest()
//            {
//                Market = "HOSE",
//                Symbol = "SSI"
//            };
//            var x = await FastConnectFastConnectClient.Get<SecuritiesDetailsRequest, SecuritiesDetailsResponse>(
//                req, apiPath: ApiDefine.GetSecuritiesDetail);
//            Console.WriteLine(JsonConvert.SerializeObject(x.DeserializeObj));
//        }

//        [TestKey((int)TemplateKey.INDEX_COMPONENT)]
//        public static async void TestIndexComponent(FastConnectClient FastConnectClient)
//        {
//            var req = new IndexComponentRequest()
//            {
//                IndexCode = "VN30"
//            };
//            var x = await FastConnectFastConnectClient.Get<IndexComponentRequest, IndexComponentResponse>(
//                req, apiPath: ApiDefine.GetSecuritiesDetail);
//            Console.WriteLine(JsonConvert.SerializeObject(x.DeserializeObj));
//        }

//        [TestKey((int)TemplateKey.INDEX_LIST)]
//        public static async void TestIndexList(FastConnectClient FastConnectClient)
//        {
//            var req = new IndexListRequest()
//            {
//                Exchange = "HOSE"
//            };
//            var x = await FastConnectFastConnectClient.Get<IndexListRequest, IndexListResponse>(
//                req, apiPath: ApiDefine.GetSecuritiesDetail);
//            Console.WriteLine(JsonConvert.SerializeObject(x.DeserializeObj));
//        }

//        [TestKey((int)TemplateKey.DAILY_OHLC)]
//        public static async void TestDailyOHLC(FastConnectClient FastConnectClient)
//        {
//            var req = new DailyOHLCRequest()
//            {
//                Symbol = "SSI",
//                FromDate = "01/12/2019",
//                ToDate = "24/12/2019"
//            };
//            var x = await FastConnectFastConnectClient.Get<DailyOHLCRequest, DailyOhlcResponse>(
//                req, apiPath: ApiDefine.GetSecuritiesDetail);
//            Console.WriteLine(JsonConvert.SerializeObject(x.DeserializeObj));
//        }

//        [TestKey((int)TemplateKey.INTRADAY_OHLC)]
//        public static async void TestIntradayOHLC(FastConnectClient FastConnectClient)
//        {
//            var req = new IntradayOHLCRequest()
//            {
//                Symbol = "SSI",
//                FromDate = "01/12/2019",
//                ToDate = "24/12/2019"
//            };
//            var x = await FastConnectFastConnectClient.Get<IntradayOHLCRequest, IntradayOHLCResponse>(
//                req, apiPath: ApiDefine.GetSecuritiesDetail);
//            Console.WriteLine(JsonConvert.SerializeObject(x.DeserializeObj));
//        }

//        [TestKey((int)TemplateKey.DAILY_INDEX)]
//        public static async void TestDailyIndex(FastConnectClient FastConnectClient)
//        {
//            var req = new DailyIndexRequest()
//            {
//                PageSize = 100,
//                PageIndex = 1,
//                IndexId = "VN30",
//                ToDate = "11/12/2019",
//                FromDate = "11/11/2019",
//                Order = "SAMPLE",
//                OrderBy = "SAMPLE",
//                RequestId = "SAMPLE"
//            };
//            var x = await FastConnectFastConnectClient.Get<DailyIndexRequest, DailyIndexResponse>(
//                req, apiPath: ApiDefine.GetSecuritiesDetail);
//            Console.WriteLine(JsonConvert.SerializeObject(x.DeserializeObj));
//        }

//        [TestKey((int)TemplateKey.DAILY_STOCK_PRICE)]
//        public static async void TestDailyStockPrice(FastConnectClient FastConnectClient)
//        {
//            var req = new StockPriceRequest()
//            {
//                Symbol = "SSI",
//                Market = "HOSE",
//                FromDate = "11/11/2019",
//                ToDate = "11/12/2019",
//                PageIndex = 1,
//                PageSize = 100
//            };
//            var x = await FastConnectFastConnectClient.Get<StockPriceRequest, StockPriceResponse>(
//                req, apiPath: ApiDefine.GetStockPrice);
//            Console.WriteLine(JsonConvert.SerializeObject(x.DeserializeObj));
//        }

//        //[TestKey((int)TemplateKey.NEWORDER)]
//        //public static async void TestNewOrder(FastConnectClient FastConnectClient)
//        //{
//        //    var req = new SSI.TradingAPI.DataContract.Requests.NewOrderRequest()
//        //    {
//        //        Account = "1810011",
//        //        BuySell = "B",
//        //        Market = "VN",
//        //        OrderType = "LO",
//        //        Price = 30000.0,
//        //        Quantity = 100,
//        //        InstrumentID = "SSI",
//        //        ChannelID = "XL",
//        //        RequestID = "1234567"
//        //    };
//        //    var x = await FastConnectFastConnectClient.Get<SSI.TradingAPI.DataContract.Requests.NewOrderRequest, SSI.TradingAPI.DataContract.Responses.NewOrderResponse>(
//        //        req, apiPath: ApiDefine.GetSecuritiesDetail);
//        //    Console.WriteLine(JsonConvert.SerializeObject(x.DeserializeObj));
//        //}

//        //[TestKey((int)TemplateKey.MODIFYORDER)]
//        //public static async void TestModifyOrder(FastConnectClient FastConnectClient, string orderID, string qty, string price)
//        //{
//        //    var req = new SSI.TradingAPI.DataContract.Requests.ModifyOrderRequest()
//        //    {
//        //        Account = "1810011",
//        //        OrderID = orderID,
//        //        Price = double.Parse(price),
//        //        Quantity = long.Parse(qty),
//        //        BuySell = "B",
//        //        InstrumentID = "SSI",
//        //        MarketID = "VN",
//        //        OrderType = "LO",
//        //        RequestID = "1234567"
//        //    };
//        //    var x = await FastConnectFastConnectClient.Get<SSI.TradingAPI.DataContract.Requests.ModifyOrderRequest, SSI.TradingAPI.DataContract.Responses.ModifyOrderResponse>(
//        //        req, apiPath: ApiDefine.GetSecuritiesDetail);
//        //    Console.WriteLine(JsonConvert.SerializeObject(x.DeserializeObj));
//        //}

//        //[TestKey((int)TemplateKey.CANCELORDER)]
//        //public static async void TestCancelOrder(FastConnectClient FastConnectClient, string orderId)
//        //{
//        //    var req = new SSI.TradingAPI.DataContract.Requests.ModifyOrderRequest()
//        //    {
//        //        Account = "1810011",
//        //        OrderID = orderId,
//        //        BuySell = "B",
//        //        InstrumentID = "SSI",
//        //        MarketID = "VN",
//        //        RequestID = "1234567"
//        //    };
//        //    var x = await FastConnectFastConnectClient.Get<SSI.TradingAPI.DataContract.Requests.ModifyOrderRequest, SSI.TradingAPI.DataContract.Responses.ModifyOrderResponse>(
//        //        req, apiPath: ApiDefine.GetSecuritiesDetail);
//        //    Console.WriteLine(JsonConvert.SerializeObject(x.DeserializeObj));
//        //}

//        //[TestKey((int)TemplateKey.DERPOSITION)]
//        //public static async void TestDerPosion(FastConnectClient FastConnectClient)
//        //{
//        //    var req = new SSI.TradingAPI.DataContract.Requests.DerPositionRequest()
//        //    {
//        //        Account = "0032528",
//        //        QuerySummary = true,
//        //    };
//        //    var x = await FastConnectFastConnectClient.Get<SSI.TradingAPI.DataContract.Requests.DerPositionRequest, SSI.TradingAPI.DataContract.Responses.DerPositionResponse>(
//        //        req, apiPath: ApiDefine.GetSecuritiesDetail);
//        //    Console.WriteLine(JsonConvert.SerializeObject(x.DeserializeObj));
//        //}

//        //[TestKey((int)TemplateKey.ORDERHISTORIES)]
//        //public static async void TestOrderHistory(FastConnectClient FastConnectClient)
//        //{
//        //    var req = new SSI.TradingAPI.DataContract.Requests.OrderHistoryRequest()
//        //    {
//        //        Account = "0163271",
//        //        StartDate = "01/08/2019 10:00:00",
//        //        EndDate = "15/08/2019 16:00:00"
//        //    };
//        //    var x = await FastConnectFastConnectClient.Get<SSI.TradingAPI.DataContract.Requests.OrderHistoryRequest, SSI.TradingAPI.DataContract.Responses.OrderHistoryResponse>(
//        //        req, apiPath: ApiDefine.GetSecuritiesDetail);
//        //    Console.WriteLine(JsonConvert.SerializeObject(x.DeserializeObj));
//        //}

//        //[TestKey((int)TemplateKey.STOCKPOSITION)]
//        //public static async void TestStockPosition(FastConnectClient FastConnectClient)
//        //{
//        //    var req = new SSI.TradingAPI.DataContract.Requests.StockPositionRequest()
//        //    {
//        //        Account = "0163271",
//        //    };
//        //    var x = await FastConnectFastConnectClient.Get<SSI.TradingAPI.DataContract.Requests.StockPositionRequest, SSI.TradingAPI.DataContract.Responses.StockPositionResponse>(
//        //        req, apiPath: ApiDefine.GetSecuritiesDetail);
//        //    Console.WriteLine(JsonConvert.SerializeObject(x.DeserializeObj));
//        //}

//        //[TestKey((int)TemplateKey.MAXBUYQTY)]
//        //public static async void TestMaxBuyQty(FastConnectClient FastConnectClient)
//        //{
//        //    var req = new SSI.TradingAPI.DataContract.Requests.MaxBuyQtyRequest()
//        //    {
//        //        Account = "1810011",
//        //        InstrumentID = "SSI",
//        //        Price = 22000
//        //    };
//        //    var x = await FastConnectFastConnectClient.Get<SSI.TradingAPI.DataContract.Requests.MaxBuyQtyRequest, SSI.TradingAPI.DataContract.Responses.MaxBuyQtyResponse>(
//        //        req, apiPath: ApiDefine.GetSecuritiesDetail);
//        //    Console.WriteLine(JsonConvert.SerializeObject(x.DeserializeObj));
//        //}

//        //[TestKey((int)TemplateKey.MAXSELLQTY)]
//        //public static async void TestMaxSellQty(FastConnectClient FastConnectClient)
//        //{
//        //    var req = new SSI.TradingAPI.DataContract.Requests.MaxSellQtyRequest()
//        //    {
//        //        Account = "1810011",
//        //        InstrumentID = "SSI",
//        //        Price = 22000
//        //    };
//        //    var x = await FastConnectFastConnectClient.Get<SSI.TradingAPI.DataContract.Requests.MaxSellQtyRequest, SSI.TradingAPI.DataContract.Responses.MaxSellQtyResponse>(
//        //        req, apiPath: ApiDefine.GetSecuritiesDetail);
//        //    Console.WriteLine(JsonConvert.SerializeObject(x.DeserializeObj));
//        //}

//        //[TestKey((int)TemplateKey.ACCOUNTBALANCE)]
//        //public static async void TestAccBalance(FastConnectClient FastConnectClient)
//        //{
//        //    var req = new SSI.TradingAPI.DataContract.Requests.AccountBalanceRequest()
//        //    {
//        //        Account = "1810011"
//        //    };
//        //    var x = await FastConnectFastConnectClient.Get<SSI.TradingAPI.DataContract.Requests.AccountBalanceRequest, SSI.TradingAPI.DataContract.Responses.AccountBalanceResponse>(
//        //        req, apiPath: ApiDefine.GetSecuritiesDetail);
//        //    Console.WriteLine(JsonConvert.SerializeObject(x.DeserializeObj));
//        //}

//        //[TestKey((int)TemplateKey.DERACCOUNTBALANCE)]
//        //public static async void TestDerAccBalance(FastConnectClient FastConnectClient)
//        //{
//        //    var req = new SSI.TradingAPI.DataContract.Requests.DerAccountBalanceRequest()
//        //    {
//        //        Account = "1810011"
//        //    };
//        //    var x = await FastConnectFastConnectClient.Get<SSI.TradingAPI.DataContract.Requests.DerAccountBalanceRequest, SSI.TradingAPI.DataContract.Responses.DerAccountBalanceResponse>(
//        //        req, apiPath: ApiDefine.GetSecuritiesDetail);
//        //    Console.WriteLine(JsonConvert.SerializeObject(x.DeserializeObj));
//        //}
        
//    }
//}
