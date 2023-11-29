using System;
using System.Threading.Tasks;
using Serilog;
using System.Threading;
using Microsoft.AspNet.SignalR.Client;
using Microsoft.AspNet.SignalR.Client.Transports;
using System.Net;

namespace SSI.FCData
{
    public delegate void OnReceived(string data);
    public class StreamingClient
    {
        private HubConnection _hubConnection;
        string _url;
        private readonly ILogger _logger;
        private readonly AuthenProvider _authenticationProvider;

        private const string HUB_NAME = "FcMarketDataV2Hub";
        public delegate void DelegateRunner(string data);
        private IHubProxy _hubProxy;
        private event OnReceived _onBroadcast;
        private event OnReceived _onError;
        private Timer ReconnectTimer;
        private string _channelSub;
        public const string HUB_ENDPOINT = "v2.0/signalr";
        public StreamingClient(string url, AuthenProvider authenProvider, ILogger logger = null)
        {
            _url = url;
            _authenticationProvider = authenProvider;
            _logger = logger;
        }
        public StreamingClient(string url, APIClient apiClient, ILogger logger = null)
        {
            _url = url;
            _authenticationProvider = apiClient.AuthenProvider;
            _logger = logger;
        }
        public StreamingClient(string streamingUrl, string apiUrl, string consumerId, string consumerSecret, ILogger logger = null)
        {
            _url = streamingUrl;
            _authenticationProvider = new AuthenProvider(apiUrl, consumerId, consumerSecret, logger);
            _logger = logger;
        }
        private void CreateHubClient(string accessToken, CancellationToken cancellationToken = default)
        {
            _logger?.Information("Create hub connection with accessToken: {0}", accessToken);
            var url = _url;
            if (_url.EndsWith("/"))
                url += HUB_ENDPOINT;
            else url += "/" + HUB_ENDPOINT;
            _hubConnection = new HubConnection(url);
            _hubConnection.Headers.Add("Authorization", "Bearer " + accessToken);
            _hubProxy = _hubConnection.CreateHubProxy(HUB_NAME);

            _hubProxy.On<string>("Broadcast", On_Broadcast);
            _hubProxy.On<string>("Error", On_Error);
            _hubConnection.StateChanged += On_StateChanged;
        }
        private void SchedulerReconnect(int seconds = 3)
        {
            ReconnectTimer = new Timer((state) =>
            {
                try
                {
                    _logger?.Information("Reconnect to FcData stream!");
                    Start().Wait();
                    _hubProxy.Invoke("SwitchChannels", _channelSub);
                }
                catch (Exception ex)
                {
                    _logger.Error(ex, "Error when try to reconnect");
                }
            }, null, seconds * 1000, Timeout.Infinite);
        }
        public void On_StateChanged(Microsoft.AspNet.SignalR.Client.StateChange stateChange)
        {
            try
            {
                _logger?.Information($"Order hub client change state from {stateChange.OldState} to {stateChange.NewState}");
                switch (stateChange.NewState)
                {
                    case Microsoft.AspNet.SignalR.Client.ConnectionState.Connecting:
                        break;
                    case Microsoft.AspNet.SignalR.Client.ConnectionState.Connected:
                        break;
                    case Microsoft.AspNet.SignalR.Client.ConnectionState.Reconnecting:
                        _hubConnection.Headers.Remove("Authorization");
                        _hubConnection.Headers.Add("Authorization", "Bearer " + _authenticationProvider.GetAccessToken().GetAwaiter().GetResult());
                        break;
                    case Microsoft.AspNet.SignalR.Client.ConnectionState.Disconnected:
                        SchedulerReconnect();// Reconnect if reconnect failed to disconnect
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                _logger?.Error(ex, "Failed to process On_StateChanged event");
            }
        }
        public async Task SwitchChannels(string filterCondition)
        {
            if (string.IsNullOrEmpty(filterCondition)) return;
            _channelSub = filterCondition;
            if(_hubProxy != null)
                await _hubProxy.Invoke("SwitchChannels", _channelSub);
        }
        public void On_Broadcast(string data)
        {
            try
            {
                _onBroadcast?.Invoke(data);
                _logger.Information(data);
            }
            catch (Exception ex)
            {
                _logger?.Error(ex, "Failed when process broadcast event");
            }
        }
        public void On_Error(string msg)
        {
            try
            {
                _onError?.Invoke(msg);
            }
            catch (Exception ex)
            {
                _logger?.Error(ex, "Failed when process error");
            }
        }
        public async Task Start(CancellationToken cancellationToken = default)
        {
            
            var accessToken = await _authenticationProvider.GetAccessToken();
            CreateHubClient(accessToken, cancellationToken);
            await _hubConnection.Start(new WebSocketTransport());
        }

        public void CreateHandleCallBack(OnReceived @onReceived)
        {
            _onBroadcast += @onReceived;
        }
        public void CreateHandleErrorCallback(OnReceived @onReceived)
        {
            _onError += @onReceived;
        }

        public void Stop()
        {
            if (_hubConnection == null) return;
            _hubConnection.Stop();
        }
    }
}
