using Newtonsoft.Json;
using Serilog;
using SSI.FastConnect.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SSI.FastConnect.Client
{
    public class WebAPIHelper
    {
        // private readonly ILogger<WebAPIHelper> _logger;
        // private IMemoryCache _cache;

        public WebAPIHelper(/*ILogger<WebAPIHelper> logger, IMemoryCache memoryCache*/)
        {
            //_logger = logger;
            //_cache = memoryCache;
        }

        public static async Task<string> GetTokenAsync(string requestUri, string ConsumerId, string ConsumerSecret, ILogger _logger)
        {
            var accessTokenResponse = new SingleResponse<AccessTokenResponse>();
            try
            {
                string uriAccessToken = $"{requestUri }{ApiDefineV2.AccessToken}"; 
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
                    using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, uriAccessToken))
                    {
                        var keyValues = new List<KeyValuePair<string, string>>();
                        keyValues.Add(new KeyValuePair<string, string>("ConsumerId", ConsumerId));
                        keyValues.Add(new KeyValuePair<string, string>("consumersecret", ConsumerSecret));
                        request.Content = (HttpContent)new FormUrlEncodedContent(keyValues);
                        using (HttpResponseMessage result = await httpClient.SendAsync(request))
                        {
                            if (result.IsSuccessStatusCode)
                            {
                                var res = await result.Content.ReadAsStringAsync();
                                accessTokenResponse = JsonConvert.DeserializeObject<SingleResponse<AccessTokenResponse>>(res);
                                return accessTokenResponse.data.accessToken;
                            }
                            else
                            {
                                _logger.Error(result?.StatusCode.ToString());
                                _logger.Error(result?.ReasonPhrase.ToString());
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
            }

            return null;
        }



        //public IEnumerable<T> Post<T>(string requestUri, string token, object parameter = null)
        //{
        //    try
        //    {
        //        using (HttpClient httpClient = new HttpClient(new HttpClientHandler { MaxConnectionsPerServer = 200 }))
        //        {
        //            //var token = _cache.Get(CommonConstants.CacheMemory.TOKEN_KEY)?.ToString();
        //            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        //            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
        //            using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, requestUri))
        //            {
        //                if (parameter != null)
        //                    request.Content = new FormUrlEncodedContent(((IEnumerable<PropertyInfo>)parameter.GetType().GetProperties()).Select(x => new KeyValuePair<string, string>(x.Name, x.GetValue(parameter).ToString())));
        //                using (HttpResponseMessage result = httpClient.SendAsync(request).GetAwaiter().GetResult())
        //                {
        //                    if (result.StatusCode != HttpStatusCode.OK)
        //                        throw new Exception(result.Content.ReadAsStringAsync().GetAwaiter().GetResult());
        //                    return JsonConvert.DeserializeObject<ApiResult<T>>(result.Content.ReadAsStringAsync().GetAwaiter().GetResult()).Data;
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.InnerException == null ? ex.Message : ex.InnerException.Message);
        //    }
        //    return null;
        //}

        //public async Task<IEnumerable<T>> PostAsync<T>(string requestUri, object parameter = null)
        //{
        //    try
        //    {
        //        using (HttpClient httpClient = new HttpClient(new HttpClientHandler { MaxConnectionsPerServer = 200 }))
        //        {
        //            var token = //_cache.Get(CommonConstants.CacheMemory.TOKEN_KEY)?.ToString();
        //                "eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.ew0KICAiYXVkIjogImRlZTc1MWZmYjQ5MzRkNzJhOGE3NzgyZjBmN2UxOGVmIiwNCiAgImlhdCI6IDE2NTM0NDQ2MTEsDQogICJleHAiOiAxNjUzNDczNDExLA0KICAic2NvcGUiOiB7DQogICAgIklwIjogew0KICAgICAgIklwQWRyZXNzIjogIiIsDQogICAgICAiSXNWYWxpZCI6IHRydWUNCiAgICB9LA0KICAgICJUYXJnZXQiOiBbDQogICAgICB7DQogICAgICAgICJUYXJnZXRJZCI6ICJhNjE2M2RiZmNmZTE0Y2FmOTU0MDY5NTdlOTdiODY4MSIsDQogICAgICAgICJUYXJnZXRVcmwiOiBudWxsLA0KICAgICAgICAiQ29ubmVjdGlvbk5hbWUiOiAiUFRTUyINCiAgICAgIH0sDQogICAgICB7DQogICAgICAgICJUYXJnZXRJZCI6ICJjOWU1OGQ1YTA4MDY0NTJmODk2ZDcxNDE3Y2E2N2FlNiIsDQogICAgICAgICJUYXJnZXRVcmwiOiAiaHR0cDovLzE5Mi4xNjguMjEzLjk3OjExMTQvIiwNCiAgICAgICAgIkNvbm5lY3Rpb25OYW1lIjogIkNvbnN1bWVyQVBJIg0KICAgICAgfSwNCiAgICAgIHsNCiAgICAgICAgIlRhcmdldElkIjogIjdkMTY0MDhlMTA0OTQwOTc5ZWMzNTYzMGYyNGUyMTdhIiwNCiAgICAgICAgIlRhcmdldFVybCI6ICJodHRwOi8vMTkyLjE2OC4yMTMuOTc6MTExNSIsDQogICAgICAgICJDb25uZWN0aW9uTmFtZSI6ICJEYXRhRmVlZEFQSSINCiAgICAgIH0NCiAgICBdDQogIH0sDQogICJjbGkiOiAiTkdPVCIsDQogICJzdWIiOiAiIg0KfQ.mLTHBf_0171mrLL8Lz6zTbYbj3oW_1KoDhhUVRn2nheFjhC9rRsxG0elKMI3LAcoMKTbcVAsgM7uCClEIFPc_DYRrf1piIaK5BqgbHeWT1u2SIQryFa990Z82XcoDQGDTfdWpTGb_cj1B8PhIHJB18tnVszqjPhrZDyKR_lf1_U";

        //            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        //            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
        //            using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, requestUri))
        //            {
        //                if (parameter != null)
        //                    request.Content = new FormUrlEncodedContent(((IEnumerable<PropertyInfo>)parameter.GetType()
        //                                                                .GetProperties())
        //                                                                .Select(x => new KeyValuePair<string, string>(x.Name, x.GetValue(parameter).ToString())));
        //                using (HttpResponseMessage result = await httpClient.SendAsync(request))
        //                {
        //                    if (result.StatusCode != HttpStatusCode.OK)
        //                        throw new Exception(await result.Content.ReadAsStringAsync());
        //                    return JsonConvert.DeserializeObject<ApiResult<T>>(await result.Content.ReadAsStringAsync()).Data;
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.InnerException == null ? ex.Message : ex.InnerException.Message);
        //    }
        //    return null;
        //}

        //public async Task<T> Request<T>(string requestUri, HttpMethod method, string proxyHost, int proxyPort, Dictionary<string, string> header = null, object parameter = null)
        //{
        //    try
        //    {
        //        HttpClientHandler handler = new HttpClientHandler();

        //        IWebProxy proxy;
        //        if (string.IsNullOrEmpty(proxyHost))
        //        {
        //            proxy = WebRequest.GetSystemWebProxy();
        //        }
        //        else
        //        {
        //            proxy = new WebProxy(proxyHost, proxyPort);
        //        }
        //        proxy.Credentials = CredentialCache.DefaultCredentials;
        //        handler.Proxy = proxy;
        //        using (HttpClient httpClient = new HttpClient(handler))
        //        {
        //            if (header != null)
        //            {
        //                foreach (var info in header)
        //                    httpClient.DefaultRequestHeaders.Add(info.Key, info.Value);
        //            }

        //            using (HttpRequestMessage request = new HttpRequestMessage(method, requestUri))
        //            {
        //                if (parameter != null)
        //                {
        //                    var dataAsString = System.Text.Json.JsonSerializer.Serialize(parameter);
        //                    request.Content = new StringContent(dataAsString, Encoding.UTF8, "application/json");
        //                }

        //                using (HttpResponseMessage result = await httpClient.SendAsync(request).ConfigureAwait(false))
        //                {
        //                    if (result.StatusCode == HttpStatusCode.OK)
        //                        return JsonConvert.DeserializeObject<T>(result.Content.ReadAsStringAsync().GetAwaiter().GetResult());
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.InnerException == null ? ex.Message : ex.InnerException.Message);
        //    }
        //    return default(T);
        //}

        //public async Task<IEnumerable<T>> LongPolling<T>(
        //  string requestUri,
        //  object parameter,
        //  CancellationToken cancellationToken)
        //{
        //    using (HttpClient httpClient = new HttpClient())
        //    {
        //        var token = _cache.Get(CommonConstants.CacheMemory.TOKEN_KEY)?.ToString();
        //        httpClient.Timeout = Timeout.InfiniteTimeSpan;
        //        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        //        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
        //        using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, requestUri))
        //        {
        //            if (parameter != null)
        //                request.Content = new FormUrlEncodedContent(((IEnumerable<PropertyInfo>)parameter.GetType().GetProperties()).Select(x => new KeyValuePair<string, string>(x.Name, x.GetValue(parameter).ToString())));
        //            using (HttpResponseMessage result = await httpClient.SendAsync(request, cancellationToken))
        //            {
        //                if (result.StatusCode != HttpStatusCode.OK)
        //                    throw new Exception(result.Content.ReadAsStringAsync().GetAwaiter().GetResult());
        //                return JsonConvert.DeserializeObject<ApiResult<T>>(result.Content.ReadAsStringAsync().GetAwaiter().GetResult()).Data;
        //            }
        //        }
        //    }
        //}
    }


}
