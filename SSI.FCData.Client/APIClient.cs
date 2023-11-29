using Newtonsoft.Json;
using Serilog;
using Serilog.Core;
using SSI.FCData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using SSI.FCData.Models.Request;
using SSI.FCData.Models.Response;

namespace SSI.FCData
{
    public class APIClient
    {
        private readonly AuthenProvider _authenProvider;
        private readonly ILogger _logger;
        private readonly string _apiUrl;
        public APIClient(string apiUrl, string consumerId, string consumerSecret, ILogger logger = null)
        {
            if (logger == null)
                _logger = new LoggerConfiguration().MinimumLevel.Information().WriteTo.Console().CreateLogger();
            else _logger = logger;
            _authenProvider = new AuthenProvider(apiUrl, consumerId, consumerSecret, _logger);
            _apiUrl = apiUrl;
        }
        public AuthenProvider AuthenProvider { get { return _authenProvider; } }
        private async Task<TResponse> HandlerRequest<TResponse>(string apiName, string query)
            where TResponse : class
        {
            try
            {

                var client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _authenProvider.GetAccessToken());
                string uri = string.Format($"{_apiUrl}{apiName}");
                var builder = new UriBuilder(uri) { Query = query };

                var url = builder.ToString();
                var res = await client.GetAsync(url);
                res.EnsureSuccessStatusCode();
                var content = await res.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TResponse>(content);
                
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
                throw;
            }
        }
        public Task<SecuritiesListResponse> GetSecuritiesList(SecuritiesListRequest request)
        {
            return HandlerRequest<SecuritiesListResponse>(ApiDefine.GetSecuritiesList, request.ToQueryString());
        }
        public Task<SecuritiesDetailsResponse> GetSecuritiesDetails(SecuritiesDetailsRequest request)
        {
            return HandlerRequest<SecuritiesDetailsResponse>(ApiDefine.GetSecuritiesDetail, request.ToQueryString());
        }
        public Task<IndexComponentResponse> GetIndexComponent(IndexComponentRequest request)
        {
            return HandlerRequest<IndexComponentResponse>(ApiDefine.GetIndexComponents, request.ToQueryString());
        }
        public Task<IndexListResponse> GetIndexList(IndexListRequest request)
        {
            return HandlerRequest<IndexListResponse>(ApiDefine.GetIndexList, request.ToQueryString());
        }
        public Task<DailyOhlcResponse> GetDailyOhlc(DailyOHLCRequest request)
        {
            return HandlerRequest<DailyOhlcResponse>(ApiDefine.GetDailyOhlc, request.ToQueryString());
        }
        public Task<IntradayOHLCResponse> GetIntradayOhlc(IntradayOHLCRequest request)
        {
            return HandlerRequest<IntradayOHLCResponse>(ApiDefine.GetIntradayOhlc, request.ToQueryString());
        }
        public Task<DailyIndexResponse> GetDailyIndex(DailyIndexRequest request)
        {
            return HandlerRequest<DailyIndexResponse>(ApiDefine.GetDailyIndex, request.ToQueryString());
        }
        public Task<StockPriceResponse> GetStockPrice(StockPriceRequest request)
        {
            return HandlerRequest<StockPriceResponse>(ApiDefine.GetDailyStockPrice, request.ToQueryString());
        }
        public Task<IntradayByTickResponse> GetIntradayByTick(IntradayByTickRequest request)
        {
            return HandlerRequest<IntradayByTickResponse>(ApiDefine.IntradayByTick, request.ToQueryString());
        }
    }
}
