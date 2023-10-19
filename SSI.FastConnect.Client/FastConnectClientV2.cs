using Serilog;
using SSI.FastConnect.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSI.FastConnect.Client
{
    public class FastConnectClientV2
    {
        public string Message { get; set; }
        private ServiceProcessorV2 _processor;

        public FastConnectClientV2()
        {
            
        }

        public async Task<ResponseClient<TResponse>> Get<TRequest, TResponse>(string query, string apiPath, string apiUrl, string conId, string conSecret, ILogger logger)
            where TRequest : class
            where TResponse : class
        {
            _processor = new ServiceProcessorV2().GetInstance(apiUrl, conId, conSecret, logger);
            var res = await _processor.Post<string, TResponse>(query, apiName: apiPath);
            return res;
        }
    }
}
