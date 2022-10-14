using Newtonsoft.Json;
using Serilog;
using SSI.FastConnect.Client.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SSI.FastConnect.Client
{
    internal class ServiceProcessorV2
    {
        //private static readonly object Mutex = new object();
        private readonly string _apiUrl;
        private readonly string _consumerSecret;
        private readonly string _consumerId;
        //private readonly string _consumerPublicKey;
        //private readonly string _accessToken;
        private readonly ILogger _logger = null;

        private static string _accessToken = string.Empty;
        private static long _tokenTime = 0;
        private static long _tokenTimeExpiry = 4;

        private ServiceProcessorV2(string url, string consumerId, string consumerSecret, /*string consumerPublicKey, string accessToken,*/ ILogger logger = null)
        {
            _apiUrl = url;
            _consumerId = consumerId;
            _consumerSecret = consumerSecret;
            //_consumerPublicKey = consumerPublicKey;
            //_accessToken = accessToken;
            _logger = logger;
        }

        public ServiceProcessorV2()
        {
        }

        public ServiceProcessorV2 GetInstance(string url, string consumerId, string consumerSecret, /*string consumerPublicKey, string accessToken,*/ ILogger logger = null)
        {
            return new ServiceProcessorV2(url, consumerId, consumerSecret/*, consumerPublicKey, accessToken*/, logger);
        }

        public async Task<ResponseClient<TResponse>> Post<TRequest, TResponse>(string query, string apiName)
            where TRequest : class
            where TResponse : class
        {
            var response = new ResponseClient<TResponse>();
            try
            {
                _logger?.Debug("Start validate API key.");
                if (string.IsNullOrWhiteSpace(_consumerId))
                {
                    throw new ArgumentException("Cannot find ConsumerId in application configuration");
                }
                if (string.IsNullOrWhiteSpace(_consumerSecret))
                {
                    throw new ArgumentException("Cannot find ConsumerSecret in application configuration");
                }
                //if (string.IsNullOrWhiteSpace(_consumerPublicKey))
                //{
                //    throw new ArgumentException("Cannot find ConsumerPublicKey in application configuration");
                //}
                //if (string.IsNullOrWhiteSpace(_accessToken))
                //{
                //    throw new ArgumentException("Access Token is notfound");
                //}
                if (string.IsNullOrWhiteSpace(_apiUrl))
                {
                    throw new ArgumentException("Cannot find ApiUrl key in application configuration");
                }
                if (string.IsNullOrWhiteSpace(apiName))
                {
                    throw new ArgumentException("Api function is not specify");
                }
                if (string.IsNullOrWhiteSpace(query))
                {
                    throw new ArgumentException("query request is required");
                }
                _logger?.Debug("Validate api key successful!");
                _logger?.Debug("Start make request. Encrypting request data...");

                var result = await HandlerRequest(response, apiName, query);
                return result;
            }
            catch (Exception ex)
            {
                _logger?.Error(ex.Message, ex);
                return new ResponseClient<TResponse>();
            }
        }

        public async Task ReadAccessToken()
        {
            if (!CheckTokenLifeTime())
            {
                try
                {
                    _accessToken = await WebAPIHelper.GetTokenAsync(_apiUrl, _consumerId, _consumerSecret, _logger);
                    if (string.IsNullOrEmpty(_accessToken)) throw new ArgumentException("token is null");
                    var handler = new JwtSecurityTokenHandler();
                    var jsonToken = handler.ReadToken(_accessToken);
                    var tokenS = jsonToken as JwtSecurityToken;
                    var exp = tokenS.Claims.First(claim => claim.Type == "exp").Value;
                    _tokenTime = long.Parse(exp);
                }
                catch (Exception ex)
                {
                    _logger.Error("Failed to get access token", ex);
                    throw ex;
                }
            }

        }
        private bool CheckTokenLifeTime()
        {
            try
            {
                var datetimeNow = (long)DateTime.Now.ToUniversalTime().Subtract(
                new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                ).TotalMilliseconds;
                var timeSpanNumber = _tokenTime - datetimeNow;
                if (timeSpanNumber <= 0) return false;

                return timeSpanNumber > _tokenTimeExpiry;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message, ex);
                return false; // token exp invalid
            }
        }

        private async Task<ResponseClient<TResponse>> HandlerRequest<TResponse>(ResponseClient<TResponse> response, string apiName, string query)
            where TResponse : class
        {    
            try
            {
                await ReadAccessToken();

                var client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken);
                string uri = string.Format($"{_apiUrl}{apiName}");
                var builder = new UriBuilder(uri) { Query = query };

                var url = builder.ToString();
                var res = await client.GetAsync(url);
                var content = await res.Content.ReadAsStringAsync();
                if (res.IsSuccessStatusCode)
                {
                    response.StatusCode = (int)res.StatusCode;
                    response.DeserializeObj = JsonConvert.DeserializeObject<TResponse>(content);
                }
                else
                {
                    response.StatusCode = (int)res.StatusCode;
                    response.Message = res.ReasonPhrase;
                    _logger.Error( $"status {(int)res.StatusCode}");
                    _logger.Error(res?.Content.ToString());
                    _logger.Error(res?.ReasonPhrase);
                }
                return response;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
                throw;
            }

        }

    }
}
