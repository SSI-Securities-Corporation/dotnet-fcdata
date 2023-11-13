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
using SSI.FastConnect.RealTimeClient;
using Microsoft.Extensions.Configuration;
using Unity;
using Microsoft.AspNet.SignalR.Client.Http;

namespace DotnetClientTest
{
    public class ResourceTestTemplateV2
    {
        private static string _pathDataFile = Path.Combine(Directory.GetCurrentDirectory(), Path.GetFileName("data.json"));
        private static string _contentDataFile = string.Empty;
        private ILogger _logger;

        public static string _apiUrl = string.Empty;
        public static string _conId = string.Empty;
        public static string _conSecret = string.Empty;
        public static string _channelSub =string.Empty;
        public static string _streamURL = string.Empty;
        private FastConnectClientV2 FastConnectFastConnectClient = new FastConnectClientV2();

        public ResourceTestTemplateV2(IConfigurationRoot configuration, ILogger logger)
        {
            _contentDataFile = File.ReadAllText(_pathDataFile);
            _apiUrl = configuration["FastConnectUrl"];
            _conId = configuration["ConsumerId"];
            _conSecret = configuration["ConsumerSecret"];
            _channelSub = configuration["channels"];
            _streamURL = configuration["StreamURL"];
            _logger = logger;

            
        }


        [TestKey((int)TemplateKey.SECURITIES_LIST)]
        public async void TestSecuritiesList()
        {
            try
            {
                var rawObj = JObject.Parse(_contentDataFile)["SecuritiesListRequest"].ToString();
                var req = JsonConvert.DeserializeObject<SecuritiesListRequest>(rawObj);
                var x = await FastConnectFastConnectClient.Get<SecuritiesListRequest, SecuritiesListResponse>(
                    req.GetQueryString(), ApiDefineV2.GetSecuritiesList, _apiUrl, _conId, _conSecret, _logger);
                Console.WriteLine(JsonConvert.SerializeObject(x.DeserializeObj));
            }
            catch (Exception ex)
            {
                _logger.Error("TestSecuritiesList Error: " + ex.Message);
            }
            
        }

        [TestKey((int)TemplateKey.SECURITIES_DETAILS)]
        public async void TestSecuritiesDetail()
        {
            try
            {
                var rawObj = JObject.Parse(_contentDataFile)["SecuritiesDetailsRequest"].ToString();
                var req = JsonConvert.DeserializeObject<SecuritiesDetailsRequest>(rawObj);

                var x = await FastConnectFastConnectClient.Get<SecuritiesDetailsRequest, SecuritiesDetailsResponse>(
                    req.GetQueryString(), apiPath: ApiDefineV2.GetSecuritiesDetail, _apiUrl, _conId, _conSecret, _logger);
                Console.WriteLine(JsonConvert.SerializeObject(x.DeserializeObj));
            }
            catch (Exception ex)
            {
                _logger.Error("TestSecuritiesDetail Error: " + ex.Message);
            }
            
        }

        [TestKey((int)TemplateKey.INDEX_COMPONENT)]
        public async void TestIndexComponent()
        {
            try
            {
                var rawObj = JObject.Parse(_contentDataFile)["IndexComponentRequest"].ToString();
                var req = JsonConvert.DeserializeObject<IndexComponentRequest>(rawObj);

                var x = await FastConnectFastConnectClient.Get<IndexComponentRequest, IndexComponentResponse>(
                    req.GetQueryString(), apiPath: ApiDefineV2.GetIndexComponents, _apiUrl, _conId, _conSecret, _logger);
                Console.WriteLine(JsonConvert.SerializeObject(x.DeserializeObj));
            }
            catch (Exception ex)
            {
                _logger.Error("TestIndexComponent Error: " + ex.Message);
            }
            
        }

        [TestKey((int)TemplateKey.INDEX_LIST)]
        public async void TestIndexList()
        {
            try
            {
                var rawObj = JObject.Parse(_contentDataFile)["IndexListRequest"].ToString();
                var req = JsonConvert.DeserializeObject<IndexListRequest>(rawObj);

                var x = await FastConnectFastConnectClient.Get<IndexListRequest, IndexListResponse>(
                    req.GetQueryString(), apiPath: ApiDefineV2.GetIndexList, _apiUrl, _conId, _conSecret, _logger);
                Console.WriteLine(JsonConvert.SerializeObject(x.DeserializeObj));
            }
            catch (Exception ex)
            {
                _logger.Error("TestIndexList Error: " + ex.Message);
            }
            
        }

        [TestKey((int)TemplateKey.DAILY_OHLC)]
        public async void TestDailyOHLC()
        {
            try
            {
                var rawObj = JObject.Parse(_contentDataFile)["DailyOhlcRequest"].ToString();
                var req = JsonConvert.DeserializeObject<DailyOHLCRequest>(rawObj);

                var x = await FastConnectFastConnectClient.Get<DailyOHLCRequest, DailyOhlcResponse>(
                    req.GetQueryString(), apiPath: ApiDefineV2.GetDailyOhlc, _apiUrl, _conId, _conSecret, _logger);
                Console.WriteLine(JsonConvert.SerializeObject(x.DeserializeObj));
            }
            catch (Exception ex)
            {
                _logger.Error("TestDailyOHLC Error: " + ex.Message);
            }
            
        }

        [TestKey((int)TemplateKey.INTRADAY_OHLC)]
        public async void TestIntradayOHLC()
        {
            try
            {
                var rawObj = JObject.Parse(_contentDataFile)["IntradayOhlcRequest"].ToString();
                var req = JsonConvert.DeserializeObject<IntradayOHLCRequest>(rawObj);

                var x = await FastConnectFastConnectClient.Get<IntradayOHLCRequest, IntradayOHLCResponse>(
                    req.GetQueryString(), apiPath: ApiDefineV2.GetIntradayOhlc, _apiUrl, _conId, _conSecret, _logger);
                Console.WriteLine(JsonConvert.SerializeObject(x.DeserializeObj));
            }
            catch (Exception ex)
            {
                _logger.Error("TestIntradayOHLC Error: " + ex.Message);
            }
        }

        [TestKey((int)TemplateKey.DAILY_INDEX)]
        public async void TestDailyIndex()
        {
            try
            {
                var rawObj = JObject.Parse(_contentDataFile)["DailyIndexRequest"].ToString();
                var req = JsonConvert.DeserializeObject<DailyIndexRequest>(rawObj);

                var x = await FastConnectFastConnectClient.Get<DailyIndexRequest, DailyIndexResponse>(
                    req.GetQueryString(), apiPath: ApiDefineV2.GetDailyIndex, _apiUrl, _conId, _conSecret, _logger);
                Console.WriteLine(JsonConvert.SerializeObject(x.DeserializeObj));
            }
            catch (Exception ex)
            {
                _logger.Error("TestDailyIndex Error: " + ex.Message);
            }
            
        }

        [TestKey((int)TemplateKey.DAILY_STOCK_PRICE)]
        public async void TestDailyStockPrice()
        {
            try
            {
                var rawObj = JObject.Parse(_contentDataFile)["StockPriceRequest"].ToString();
                var req = JsonConvert.DeserializeObject<StockPriceRequest>(rawObj);

                var x = await FastConnectFastConnectClient.Get<StockPriceRequest, StockPriceResponse>(
                                        req.GetQueryString(), apiPath: ApiDefineV2.GetDailyStockPrice, _apiUrl, _conId, _conSecret, _logger);
                Console.WriteLine(JsonConvert.SerializeObject(x.DeserializeObj));
            }
            catch (Exception ex)
            {
                _logger.Error("TestDailyStockPrice Error: " + ex.Message);
            }
            
        }

        [TestKey((int)TemplateKey.INTRADAY_BY_TICK)]
        public async void TestIntradayByTick()
        {
            try
            {
                var rawObj = JObject.Parse(_contentDataFile)["IntradayByTickRequest"].ToString();
                var req = JsonConvert.DeserializeObject<IntradayByTickRequest>(rawObj);

                var x = await FastConnectFastConnectClient.Get<IntradayByTickRequest, IntradayByTickResponse>(
                                        req.GetQueryString(), apiPath: ApiDefineV2.IntradayByTick, _apiUrl, _conId, _conSecret, _logger);
                Console.WriteLine(JsonConvert.SerializeObject(x.DeserializeObj));
            } catch (Exception ex) {
                _logger.Error("TestIntradayByTick Error: " + ex.Message);
            }
            
        }


        // Stream
        [TestKey((int)TemplateKey.STREAM)]
        public async Task TestStreamData()
        {
            try
            {
                var authenProvider = new AuthenProvider(_apiUrl, _conId, _conSecret, _logger);
                var hubClient = new MarketDataStreamingClientV2(_streamURL, _channelSub, authenProvider, _logger);
                await hubClient.Start();
                await hubClient.SwitchChannels(_channelSub);
            } catch (Exception ex)
            {
                _logger.Error("TestStreamData Error: " + ex.Message);
            }
            
        }
    }
}
