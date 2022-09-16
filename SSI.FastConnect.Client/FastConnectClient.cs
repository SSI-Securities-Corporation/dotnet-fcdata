using System;
using System.Configuration;
using System.Threading.Tasks;
using SSI.FastConnect.Client.Models;

namespace SSI.FastConnect.Client
{
    public class FastConnectClient
    {
        public string Message { get; set; }
        private readonly ServiceProcessor _processor;

        public FastConnectClient(string apiUrl, string conId, string conSecret, string pubKey, log4net.ILog logger = null)
        {
            _processor = new ServiceProcessor().GetInstance(apiUrl, conId, conSecret, pubKey, logger);
        }

        public async Task<ResponseClient<TResponse>> Get<TRequest, TResponse>(TRequest objRequest, string apiPath)
            where TRequest : class
            where TResponse : class
        {
            var res = await _processor.Post<TRequest, TResponse>(objRequest, apiName: apiPath);
            return res;
        }
    }
}
