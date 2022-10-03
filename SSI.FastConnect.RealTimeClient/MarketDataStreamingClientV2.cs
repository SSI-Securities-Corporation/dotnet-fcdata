using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SSI.FastConnect.DataContracts.Realtime;
using SSI.FastConnect.Client.Helpers;
using SSI.FastConnect.Client;
using Serilog;
using System.Threading;
using Microsoft.AspNet.SignalR.Client;
using Microsoft.AspNet.SignalR.Client.Transports;

namespace SSI.FastConnect.RealTimeClient
{
    public delegate void OnReceived(string data);
    public class MarketDataStreamingClientV2
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
        public MarketDataStreamingClientV2(string url, string channelSub, AuthenProvider authenProvider, ILogger logger = null)
        {
            _url = url;
            _authenticationProvider = authenProvider;
            _logger = logger;
            _channelSub = channelSub;
        }
        private async void CreateHubClient(string accessToken, CancellationToken cancellationToken = default)
        {
            _logger?.Information("Create hub connection with accesssToken: {0}", accessToken);
            _hubConnection = new HubConnection(_url);
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
                _logger?.Information("Reconect to FcData stream!");
                Start().Wait();
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
                _logger?.Error(ex, "Failed to proccess On_StateChanged event");
            }
        }
        public async Task SwitchChannels(string filterCondition)
        {
            if (string.IsNullOrEmpty(filterCondition)) return;
            if(_hubProxy != null)
                await _hubProxy.Invoke("SwitchChannels", filterCondition);
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
