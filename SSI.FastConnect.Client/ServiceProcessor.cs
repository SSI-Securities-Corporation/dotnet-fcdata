using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Serilog;
using SSI.FastConnect.Client.Helpers;
using SSI.FastConnect.Client.Models;

namespace SSI.FastConnect.Client
{
    internal class ServiceProcessor
    {
        private static readonly object Mutex = new object();
        private readonly string _apiUrl;
        private readonly string _consumerSecret;
        private readonly string _consumerId;
        private readonly string _consumerPublicKey;
        private readonly ILogger _logger = null;

        public ServiceProcessor() { }

        private ServiceProcessor(string url, string consumerId, string consumerSecret, string consumerPublicKey, ILogger logger = null)
        {
            _apiUrl = url;
            _consumerId = consumerId;
            _consumerSecret = consumerSecret;
            _consumerPublicKey = consumerPublicKey;
            _logger = logger;
        }

        public ServiceProcessor GetInstance(string url, string consumerId, string consumerSecret, string consumerPublicKey, ILogger logger = null)
        {
            return new ServiceProcessor(url, consumerId, consumerSecret, consumerPublicKey);
        }

        internal async Task<ResponseClient<TResponse>> Post<TRequest, TResponse>(TRequest objReq, string apiName)
            where TRequest : class
            where TResponse : class
        {
            var response = new Lazy<ResponseClient<TResponse>>();
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
                if (string.IsNullOrWhiteSpace(_consumerPublicKey))
                {
                    throw new ArgumentException("Cannot find ConsumerPublicKey in application configuration");
                }
                if (string.IsNullOrWhiteSpace(_apiUrl))
                {
                    throw new ArgumentException("Cannot find ApiUrl key in application configuration");
                }
                if (string.IsNullOrWhiteSpace(apiName))
                {
                    throw new ArgumentException("Api function is not specify");
                }
                if (objReq == null)
                {
                    throw new ArgumentException("Object request is required");
                }
                _logger?.Debug("Validate api key successful!");
                _logger?.Debug("Start make request. Encrypting request data...");
                var wrapperReq = MakeRequest(objReq, _consumerSecret, apiName, out byte[] byteKey);
                if (wrapperReq == null)
                {
                    throw new ArgumentException("Cannot create wrapper request");
                }
                _logger?.Debug("Encrypted!");
                _logger?.Debug("Start send request to server.");
                var task = await PostAsync(response.Value, wrapperReq, byteKey);
                return task;
            }
            catch (Exception ex)
            {
                _logger?.Fatal("Error", ex);
                throw ex;
            }
        }

        private async Task<ResponseClient<TResponse>> PostAsync<TResponse>(ResponseClient<TResponse> response, RequestClient req, byte[] byteKey)
           where TResponse : class
        {
            var httpClient = new HttpClient { BaseAddress = new Uri(_apiUrl) };
            httpClient.DefaultRequestHeaders
                .Accept
                .Add(
                new MediaTypeWithQualityHeaderValue("application/x-protobuf"));
            var bytes2Post = CommonHelper.ProtoSerialize(req);
            var byteArrayContent = new ByteArrayContent(bytes2Post);
            byteArrayContent.Headers.ContentType = new MediaTypeHeaderValue("application/x-protobuf");
            _logger?.Debug($"Post to api/{req.Type}");
            var post = httpClient.PostAsync($"api/{req.Type}", byteArrayContent).Result;
            _logger?.Debug($"Done with status {post.StatusCode}");
            if (post.IsSuccessStatusCode)
            {
                var result = await post.Content.ReadAsByteArrayAsync();
                if (result == null)
                {
                    throw new HttpRequestException("Cannot connect to the server");
                }
                _logger?.Debug($"Start decrypting response data...");
                var deserializeObj = CommonHelper.ProtoDeserialize<ResponseClient<TResponse>>(result);
                if (deserializeObj == null) return response;
                response.Message = deserializeObj.Message;
                response.StatusCode = deserializeObj.StatusCode;
                if (deserializeObj.Data != null)
                {
                    response.DeserializeObj = CommonHelper.DeserializeObjFromByteData<TResponse>(deserializeObj.Data, _consumerSecret, byteKey);
                    _logger?.Debug($"Decrypted!");
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(post.ReasonPhrase))
                {
                    throw new HttpRequestException("Request is not success");
                }
                throw new HttpRequestException(post.ReasonPhrase);
            }
            return response;
        }

        private RequestClient MakeRequest<T>(T obj, string secret, string apiName, out byte[] byteKey) where T : class
        {
            byteKey = new byte[CommonConstant.BYTE_SIZE];
            using (var random = new RNGCryptoServiceProvider())
            {
                random.GetBytes(byteKey);
            }
            var requestObj = new RequestClient
            {
                Dic = new Dictionary<string, string>
                {
                    {"ConsumerId", _consumerId}, {"ConsumerSecret", _consumerSecret}
                },
                Type = apiName,
                Data = CommonHelper.AddSerialization2Obj(obj, secret, byteKey),
                Key = CipherHelper.Encryption(byteKey, _consumerPublicKey)
            };
            if (string.IsNullOrWhiteSpace(requestObj.Key))
            {
                throw new ArgumentException("There are something happens with the key");
            }
            return requestObj;
        }
    }
}
