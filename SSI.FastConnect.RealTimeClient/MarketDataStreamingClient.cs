using System;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SSI.FastConnect.DataContracts.Realtime;
using SSI.FastConnect.Client.Helpers;

namespace SSI.FastConnect.RealTimeClient
{
    public enum ConnectionState 
    {
        Connecting = 0,
        Connected = 1,
        Reconnecting = 2,
        Disconnected = 3
    }
    public class StateChange
    {
        public StateChange(ConnectionState oldState, ConnectionState newState)
        {
            OldState = oldState;
            NewState = newState;
        }

        //
        // Summary:
        //     Gets the old state of the connection.
        public ConnectionState OldState { get; }
        //
        // Summary:
        //     Gets the new state of the connection.
        public ConnectionState NewState { get; }
    }
    public delegate void StateChangeDelegate(StateChange stateChange);
    public class MarketDataStreamingClient : IDisposable
    {
        private const string HUB_NAME = "FcMarketDataHub";
        public delegate void DelegateRunner(string data);

        private HubConnection _hubConnection;
        private readonly IHubProxy _hubProxy;
        private event StateChangeDelegate _onStateChange;

        public MarketDataStreamingClient(MarketDataConfiguration config = null)
        {
            _hubProxy = InitClient(config);
        }
        public void OnStateChange(StateChangeDelegate stateChange)
        {
            _onStateChange += stateChange;
        }
        /// <summary>
        /// DataHandleMessage is DelegateRunner for handle Broadcast channel from hub
        /// </summary>
        /// <param name="dataHandleMessage"></param>
        /// <param name="filterCondition"></param>
        /// <returns></returns>

        public async Task Connect(DelegateRunner dataHandleMessage, string filterCondition)
        {
            if (_hubProxy != null)
            {
                try
                {
                    _hubProxy.On<string>("Error", data => { dataHandleMessage(data); });
                    _hubProxy.On<string>("Broadcast", data =>
                    {
                        ProcessData(data, dataHandleMessage);
                    });
                    if (_hubConnection.State == Microsoft.AspNet.SignalR.Client.ConnectionState.Connected)
                    {
                        _hubConnection.Stop();
                    }
                    await _hubConnection.Start();
                    await _hubProxy.Invoke("SwitchChannels", filterCondition);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error {ex.Message} {ex.StackTrace})");
                }
            }
        }

        public async Task SwitchChannels(string filterCondition)
        {
            if (string.IsNullOrEmpty(filterCondition)) return;
            await _hubProxy.Invoke("SwitchChannels", filterCondition);
        }

        private void ProcessData(string data, DelegateRunner delRunner)
        {
            var bytes = Convert.FromBase64String(data);
            var obj = CommonHelper.ProtoDeserialize<MdhfData>(bytes);
            if (obj != null)
            {
                dynamic jObject = JObject.Parse(obj.Content);
                if (jObject != null) delRunner(JsonConvert.SerializeObject(obj));
            }
            else
            {
                delRunner(JsonConvert.SerializeObject(obj));
            }
           // delRunner(data);
        }

        private IHubProxy InitClient(MarketDataConfiguration config)
        {
            if (config == null) throw new Exception("Config is null");
            if (string.IsNullOrWhiteSpace(config.HubUrl)) throw new Exception("Api url null");
            if (string.IsNullOrWhiteSpace(config.ConnectId)) throw new Exception("Connect id null");
            if (string.IsNullOrWhiteSpace(config.ConnectSecret)) throw new Exception("Connect secret null");

            _hubConnection = new HubConnection(config.HubUrl);
            _hubConnection.Headers.Add("ConsumerId", config.ConnectId);
            _hubConnection.Headers.Add("ConsumerSecret", config.ConnectSecret);
            // _hubConnection.StateChanged += _hubConnection_StateChanged;
            // _hubConnection.Headers.Add("Authorization", "Bearer " + config.ConnectSecret);

            return _hubConnection.CreateHubProxy(HUB_NAME);
        }

        private void _hubConnection_StateChanged(Microsoft.AspNet.SignalR.Client.StateChange obj)
        {
            try
            {
                var oldVal = (ConnectionState)obj.OldState;
                var newVal = (ConnectionState)obj.NewState;
                StateChange stateChange = new StateChange(oldVal, newVal);
                _onStateChange?.Invoke(stateChange);
            }
            catch(Exception ex)
            {
                // Do anything
            }
        }

        public void Dispose()
        {
            if (_hubConnection == null) return;

            _hubConnection.Stop();
            _hubConnection.Dispose();
        }
    }
}
