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
using Serilog;

namespace DotnetClientTest
{
    public class ResourceTestTemplateV2
    {
        private static string _pathDataFile = Path.Combine(Directory.GetCurrentDirectory(), Path.GetFileName("data.json"));
        private static string _contentDataFile = string.Empty;

        private static dynamic _logger;

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
            var x = await FastConnectFastConnectClient.Get<SecuritiesListRequest, SecuritiesListResponse>(
                req.GetQueryString(), ApiDefineV2.GetSecuritiesList);
            Console.WriteLine(JsonConvert.SerializeObject(x.DeserializeObj));
        }

        [TestKey((int)TemplateKey.SECURITIES_DETAILS)]
        public async void TestSecuritiesDetail()
        {
            var rawObj = JObject.Parse(_contentDataFile)["SecuritiesDetailsRequest"].ToString();
            var req = JsonConvert.DeserializeObject<SecuritiesDetailsRequest>(rawObj);

            var x = await FastConnectFastConnectClient.Get<SecuritiesDetailsRequest, SecuritiesDetailsResponse>(
                req.GetQueryString(), apiPath: ApiDefineV2.GetSecuritiesDetail);
            Console.WriteLine(JsonConvert.SerializeObject(x.DeserializeObj));
        }

        [TestKey((int)TemplateKey.INDEX_COMPONENT)]
        public async void TestIndexComponent()
        {
            var rawObj = JObject.Parse(_contentDataFile)["IndexComponentRequest"].ToString();
            var req = JsonConvert.DeserializeObject<IndexComponentRequest>(rawObj);

            var x = await FastConnectFastConnectClient.Get<IndexComponentRequest, IndexComponentResponse>(
                req.GetQueryString(), apiPath: ApiDefineV2.GetIndexComponents);
            Console.WriteLine(JsonConvert.SerializeObject(x.DeserializeObj));
        }

        [TestKey((int)TemplateKey.INDEX_LIST)]
        public async void TestIndexList()
        {
            var rawObj = JObject.Parse(_contentDataFile)["IndexListRequest"].ToString();
            var req = JsonConvert.DeserializeObject<IndexListRequest>(rawObj);

            var x = await FastConnectFastConnectClient.Get<IndexListRequest, IndexListResponse>(
                req.GetQueryString(), apiPath: ApiDefineV2.GetIndexList);
            Console.WriteLine(JsonConvert.SerializeObject(x.DeserializeObj));
        }

        [TestKey((int)TemplateKey.DAILY_OHLC)]
        public async void TestDailyOHLC()
        {
            var rawObj = JObject.Parse(_contentDataFile)["DailyOhlcRequest"].ToString();
            var req = JsonConvert.DeserializeObject<DailyOHLCRequest>(rawObj);

            var x = await FastConnectFastConnectClient.Get<DailyOHLCRequest, DailyOhlcResponse>(
                req.GetQueryString(), apiPath: ApiDefineV2.GetDailyOhlc);
            Console.WriteLine(JsonConvert.SerializeObject(x.DeserializeObj));
        }

        [TestKey((int)TemplateKey.INTRADAY_OHLC)]
        public async void TestIntradayOHLC()
        {
            var rawObj = JObject.Parse(_contentDataFile)["IntradayOhlcRequest"].ToString();
            var req = JsonConvert.DeserializeObject<IntradayOHLCRequest>(rawObj);

            var x = await FastConnectFastConnectClient.Get<IntradayOHLCRequest, IntradayOHLCResponse>(
                req.GetQueryString(), apiPath: ApiDefineV2.GetIntradayOhlc);
            Console.WriteLine(JsonConvert.SerializeObject(x.DeserializeObj));
        }

        [TestKey((int)TemplateKey.DAILY_INDEX)]
        public async void TestDailyIndex()
        {
            var rawObj = JObject.Parse(_contentDataFile)["DailyIndexRequest"].ToString();
            var req = JsonConvert.DeserializeObject<DailyIndexRequest>(rawObj);

            var x = await FastConnectFastConnectClient.Get<DailyIndexRequest, DailyIndexResponse>(
                req.GetQueryString(), apiPath: ApiDefineV2.GetDailyIndex);
            Console.WriteLine(JsonConvert.SerializeObject(x.DeserializeObj));
        }

        [TestKey((int)TemplateKey.DAILY_STOCK_PRICE)]
        public async void TestDailyStockPrice()
        {
            var rawObj = JObject.Parse(_contentDataFile)["StockPriceRequest"].ToString();
            var req = JsonConvert.DeserializeObject<StockPriceRequest>(rawObj);

            var x = await FastConnectFastConnectClient.Get<StockPriceRequest, StockPriceResponse>(
                                    req.GetQueryString(), apiPath: ApiDefineV2.GetDailyStockPrice);
            Console.WriteLine(JsonConvert.SerializeObject(x.DeserializeObj));
        }

    }
}
