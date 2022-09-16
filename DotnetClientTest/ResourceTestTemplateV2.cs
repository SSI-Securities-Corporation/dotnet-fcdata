using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SSI.FastConnect.DataContracts.Market.Request;
using SSI.FastConnect.DataContracts.Market.Response;
using System.Configuration;
using SSI.FastConnect.Client;
using System.Web;
using SSI.FastConnect.Client.Helpers;
using System.IO;
using Newtonsoft.Json.Linq;

namespace DotnetClientTest
{
    public class ResourceTestTemplateV2
    {
        private static string _pathDataFile = Path.Combine(Directory.GetCurrentDirectory(), Path.GetFileName("data.json"));
        private static string _contentDataFile = string.Empty;

        private readonly static FastConnectClientV2 FastConnectFastConnectClient = new FastConnectClientV2
        (
          apiUrl: ConfigurationManager.AppSettings["FastConnectUrl"],
          conId: ConfigurationManager.AppSettings["FastConnectId"],
          conSecret: ConfigurationManager.AppSettings["FastConnectSecret"]
          //pubKey: ConfigurationManager.AppSettings["FastConnectPublicKey"]
        );


        public ResourceTestTemplateV2()
        {
            _contentDataFile = File.ReadAllText(_pathDataFile);
        }


        [TestKey((int)TemplateKey.SECURITIES_LIST)]
        public async void TestSecuritiesList()
        {

            var rawObj = JObject.Parse(_contentDataFile)["SecuritiesListRequest"].ToString();
            var req = JsonConvert.DeserializeObject<SecuritiesListRequest>(rawObj);
            
            //var req = new SecuritiesListRequest()
            //{
            //    Market = "HOSE"
            //};

            var x = await FastConnectFastConnectClient.Get<SecuritiesListRequest, SecuritiesListResponse>(
                req.GetQueryString(), ApiDefineV2.GetSecuritiesList);
            Console.WriteLine(JsonConvert.SerializeObject(x.DeserializeObj));
        }

        [TestKey((int)TemplateKey.SECURITIES_DETAILS)]
        public async void TestSecuritiesDetail()
        {
            var rawObj = JObject.Parse(_contentDataFile)["SecuritiesDetailsRequest"].ToString();
            var req = JsonConvert.DeserializeObject<SecuritiesDetailsRequest>(rawObj);


            //var req = new SecuritiesDetailsRequest()
            //{
            //    Market = "HOSE",
            //    Symbol = "SSI"
            //};
            var x = await FastConnectFastConnectClient.Get<SecuritiesDetailsRequest, SecuritiesDetailsResponse>(
                req.GetQueryString(), apiPath: ApiDefineV2.GetSecuritiesDetail);
            Console.WriteLine(JsonConvert.SerializeObject(x.DeserializeObj));
        }

        [TestKey((int)TemplateKey.INDEX_COMPONENT)]
        public async void TestIndexComponent()
        {

            var rawObj = JObject.Parse(_contentDataFile)["IndexComponentRequest"].ToString();
            var req = JsonConvert.DeserializeObject<IndexComponentRequest>(rawObj);

            //var req = new IndexComponentRequest()
            //{
            //    IndexCode = "VN30"
            //};
            var x = await FastConnectFastConnectClient.Get<IndexComponentRequest, IndexComponentResponse>(
                req.GetQueryString(), apiPath: ApiDefineV2.GetSecuritiesDetail);
            Console.WriteLine(JsonConvert.SerializeObject(x.DeserializeObj));
        }

        [TestKey((int)TemplateKey.INDEX_LIST)]
        public async void TestIndexList()
        {
            var rawObj = JObject.Parse(_contentDataFile)["IndexListRequest"].ToString();
            var req = JsonConvert.DeserializeObject<IndexListRequest>(rawObj);

            //var req = new IndexListRequest()
            //{
            //    Exchange = "HOSE"
            //};
            var x = await FastConnectFastConnectClient.Get<IndexListRequest, IndexListResponse>(
                req.GetQueryString(), apiPath: ApiDefineV2.GetSecuritiesDetail);
            Console.WriteLine(JsonConvert.SerializeObject(x.DeserializeObj));
        }

        [TestKey((int)TemplateKey.DAILY_OHLC)]
        public async void TestDailyOHLC()
        {
            var rawObj = JObject.Parse(_contentDataFile)["DailyOhlcRequest"].ToString();
            var req = JsonConvert.DeserializeObject<DailyOHLCRequest>(rawObj);

            //var req = new DailyOHLCRequest()
            //{
            //    Symbol = "SSI",
            //    FromDate = "01/12/2019",
            //    ToDate = "24/12/2019"
            //};
            var x = await FastConnectFastConnectClient.Get<DailyOHLCRequest, DailyOhlcResponse>(
                req.GetQueryString(), apiPath: ApiDefineV2.GetSecuritiesDetail);
            Console.WriteLine(JsonConvert.SerializeObject(x.DeserializeObj));
        }

        [TestKey((int)TemplateKey.INTRADAY_OHLC)]
        public async void TestIntradayOHLC()
        {
            var rawObj = JObject.Parse(_contentDataFile)["IntradayOhlcRequest"].ToString();
            var req = JsonConvert.DeserializeObject<IntradayOHLCRequest>(rawObj);

            //var req = new IntradayOHLCRequest()
            //{
            //    Symbol = "SSI",
            //    FromDate = "01/12/2019",
            //    ToDate = "24/12/2019"
            //};
            var x = await FastConnectFastConnectClient.Get<IntradayOHLCRequest, IntradayOHLCResponse>(
                req.GetQueryString(), apiPath: ApiDefineV2.GetSecuritiesDetail);
            Console.WriteLine(JsonConvert.SerializeObject(x.DeserializeObj));
        }

        [TestKey((int)TemplateKey.DAILY_INDEX)]
        public async void TestDailyIndex()
        {
            var rawObj = JObject.Parse(_contentDataFile)["DailyIndexRequest"].ToString();
            var req = JsonConvert.DeserializeObject<DailyIndexRequest>(rawObj);

            //var req = new DailyIndexRequest()
            //{
            //    PageSize = 100,
            //    PageIndex = 1,
            //    IndexId = "VN30",
            //    ToDate = "11/12/2019",
            //    FromDate = "11/11/2019",
            //    Order = "SAMPLE",
            //    OrderBy = "SAMPLE",
            //    RequestId = "SAMPLE"
            //};
            var x = await FastConnectFastConnectClient.Get<DailyIndexRequest, DailyIndexResponse>(
                req.GetQueryString(), apiPath: ApiDefineV2.GetSecuritiesDetail);
            Console.WriteLine(JsonConvert.SerializeObject(x.DeserializeObj));
        }

        [TestKey((int)TemplateKey.DAILY_STOCK_PRICE)]
        public async void TestDailyStockPrice()
        {
            var rawObj = JObject.Parse(_contentDataFile)["StockPriceRequest"].ToString();
            var req = JsonConvert.DeserializeObject<StockPriceRequest>(rawObj);

            //var req = new StockPriceRequest()
            //{
            //    Symbol = "SSI",
            //    Market = "HOSE",
            //    FromDate = "11/11/2019",
            //    ToDate = "11/12/2019",
            //    PageIndex = 1,
            //    PageSize = 100
            //};
            var x = await FastConnectFastConnectClient.Get<StockPriceRequest, StockPriceResponse>(
                                    req.GetQueryString(), apiPath: ApiDefineV2.GetStockPrice);
            Console.WriteLine(JsonConvert.SerializeObject(x.DeserializeObj));
        }


        //[TestKey((int)TemplateKey.NEWORDER)]
        //public static async void TestNewOrder()
        //{
        //    var req = new SSI.TradingAPI.DataContract.Requests.NewOrderRequest()
        //    {
        //        Account = "1810011",
        //        BuySell = "B",
        //        Market = "VN",
        //        OrderType = "LO",
        //        Price = 30000.0,
        //        Quantity = 100,
        //        InstrumentID = "SSI",
        //        ChannelID = "XL",
        //        RequestID = "1234567"
        //    };
        //    var x = await FastConnectFastConnectClient.Get<SSI.TradingAPI.DataContract.Requests.NewOrderRequest, SSI.TradingAPI.DataContract.Responses.NewOrderResponse>(
        //        req, apiPath: ApiDefineV2.GetSecuritiesDetail);
        //    Console.WriteLine(JsonConvert.SerializeObject(x.DeserializeObj));
        //}

        //[TestKey((int)TemplateKey.MODIFYORDER)]
        //public static async void TestModifyOrder(FastConnectClient FastConnectClient, string orderID, string qty, string price)
        //{
        //    var req = new SSI.TradingAPI.DataContract.Requests.ModifyOrderRequest()
        //    {
        //        Account = "1810011",
        //        OrderID = orderID,
        //        Price = double.Parse(price),
        //        Quantity = long.Parse(qty),
        //        BuySell = "B",
        //        InstrumentID = "SSI",
        //        MarketID = "VN",
        //        OrderType = "LO",
        //        RequestID = "1234567"
        //    };
        //    var x = await FastConnectFastConnectClient.Get<SSI.TradingAPI.DataContract.Requests.ModifyOrderRequest, SSI.TradingAPI.DataContract.Responses.ModifyOrderResponse>(
        //        req, apiPath: ApiDefineV2.GetSecuritiesDetail);
        //    Console.WriteLine(JsonConvert.SerializeObject(x.DeserializeObj));
        //}

        //[TestKey((int)TemplateKey.CANCELORDER)]
        //public static async void TestCancelOrder(FastConnectClient FastConnectClient, string orderId)
        //{
        //    var req = new SSI.TradingAPI.DataContract.Requests.ModifyOrderRequest()
        //    {
        //        Account = "1810011",
        //        OrderID = orderId,
        //        BuySell = "B",
        //        InstrumentID = "SSI",
        //        MarketID = "VN",
        //        RequestID = "1234567"
        //    };
        //    var x = await FastConnectFastConnectClient.Get<SSI.TradingAPI.DataContract.Requests.ModifyOrderRequest, SSI.TradingAPI.DataContract.Responses.ModifyOrderResponse>(
        //        req, apiPath: ApiDefineV2.GetSecuritiesDetail);
        //    Console.WriteLine(JsonConvert.SerializeObject(x.DeserializeObj));
        //}

        //[TestKey((int)TemplateKey.DERPOSITION)]
        //public static async void TestDerPosion()
        //{
        //    var req = new SSI.TradingAPI.DataContract.Requests.DerPositionRequest()
        //    {
        //        Account = "0032528",
        //        QuerySummary = true,
        //    };
        //    var x = await FastConnectFastConnectClient.Get<SSI.TradingAPI.DataContract.Requests.DerPositionRequest, SSI.TradingAPI.DataContract.Responses.DerPositionResponse>(
        //        req, apiPath: ApiDefineV2.GetSecuritiesDetail);
        //    Console.WriteLine(JsonConvert.SerializeObject(x.DeserializeObj));
        //}

        //[TestKey((int)TemplateKey.ORDERHISTORIES)]
        //public static async void TestOrderHistory()
        //{
        //    var req = new SSI.TradingAPI.DataContract.Requests.OrderHistoryRequest()
        //    {
        //        Account = "0163271",
        //        StartDate = "01/08/2019 10:00:00",
        //        EndDate = "15/08/2019 16:00:00"
        //    };
        //    var x = await FastConnectFastConnectClient.Get<SSI.TradingAPI.DataContract.Requests.OrderHistoryRequest, SSI.TradingAPI.DataContract.Responses.OrderHistoryResponse>(
        //        req, apiPath: ApiDefineV2.GetSecuritiesDetail);
        //    Console.WriteLine(JsonConvert.SerializeObject(x.DeserializeObj));
        //}

        //[TestKey((int)TemplateKey.STOCKPOSITION)]
        //public static async void TestStockPosition()
        //{
        //    var req = new SSI.TradingAPI.DataContract.Requests.StockPositionRequest()
        //    {
        //        Account = "0163271",
        //    };
        //    var x = await FastConnectFastConnectClient.Get<SSI.TradingAPI.DataContract.Requests.StockPositionRequest, SSI.TradingAPI.DataContract.Responses.StockPositionResponse>(
        //        req, apiPath: ApiDefineV2.GetSecuritiesDetail);
        //    Console.WriteLine(JsonConvert.SerializeObject(x.DeserializeObj));
        //}

        //[TestKey((int)TemplateKey.MAXBUYQTY)]
        //public static async void TestMaxBuyQty()
        //{
        //    var req = new SSI.TradingAPI.DataContract.Requests.MaxBuyQtyRequest()
        //    {
        //        Account = "1810011",
        //        InstrumentID = "SSI",
        //        Price = 22000
        //    };
        //    var x = await FastConnectFastConnectClient.Get<SSI.TradingAPI.DataContract.Requests.MaxBuyQtyRequest, SSI.TradingAPI.DataContract.Responses.MaxBuyQtyResponse>(
        //        req, apiPath: ApiDefineV2.GetSecuritiesDetail);
        //    Console.WriteLine(JsonConvert.SerializeObject(x.DeserializeObj));
        //}

        //[TestKey((int)TemplateKey.MAXSELLQTY)]
        //public static async void TestMaxSellQty()
        //{
        //    var req = new SSI.TradingAPI.DataContract.Requests.MaxSellQtyRequest()
        //    {
        //        Account = "1810011",
        //        InstrumentID = "SSI",
        //        Price = 22000
        //    };
        //    var x = await FastConnectFastConnectClient.Get<SSI.TradingAPI.DataContract.Requests.MaxSellQtyRequest, SSI.TradingAPI.DataContract.Responses.MaxSellQtyResponse>(
        //        req, apiPath: ApiDefineV2.GetSecuritiesDetail);
        //    Console.WriteLine(JsonConvert.SerializeObject(x.DeserializeObj));
        //}

        //[TestKey((int)TemplateKey.ACCOUNTBALANCE)]
        //public static async void TestAccBalance()
        //{
        //    var req = new SSI.TradingAPI.DataContract.Requests.AccountBalanceRequest()
        //    {
        //        Account = "1810011"
        //    };
        //    var x = await FastConnectFastConnectClient.Get<SSI.TradingAPI.DataContract.Requests.AccountBalanceRequest, SSI.TradingAPI.DataContract.Responses.AccountBalanceResponse>(
        //        req, apiPath: ApiDefineV2.GetSecuritiesDetail);
        //    Console.WriteLine(JsonConvert.SerializeObject(x.DeserializeObj));
        //}

        //[TestKey((int)TemplateKey.DERACCOUNTBALANCE)]
        //public static async void TestDerAccBalance()
        //{
        //    var req = new SSI.TradingAPI.DataContract.Requests.DerAccountBalanceRequest()
        //    {
        //        Account = "1810011"
        //    };
        //    var x = await FastConnectFastConnectClient.Get<SSI.TradingAPI.DataContract.Requests.DerAccountBalanceRequest, SSI.TradingAPI.DataContract.Responses.DerAccountBalanceResponse>(
        //        req, apiPath: ApiDefineV2.GetSecuritiesDetail);
        //    Console.WriteLine(JsonConvert.SerializeObject(x.DeserializeObj));
        //}

    }
}
