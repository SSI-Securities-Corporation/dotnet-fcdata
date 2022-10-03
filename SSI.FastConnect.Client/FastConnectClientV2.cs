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
        private readonly ServiceProcessorV2 _processor;

        private static ILogger _logger = new LoggerConfiguration()
          .MinimumLevel.Warning()
          .WriteTo.Console(outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
          .CreateLogger();

        public FastConnectClientV2(string apiUrl, string conId, string conSecret)
        {
            _processor = new ServiceProcessorV2().GetInstance(apiUrl, conId, conSecret, _logger);
        }

        public async Task<ResponseClient<TResponse>> Get<TRequest, TResponse>(string query, string apiPath)
            where TRequest : class
            where TResponse : class
        {
            var res = await _processor.Post<string, TResponse>(query, apiName: apiPath);
            return res;
        }
    }
}
