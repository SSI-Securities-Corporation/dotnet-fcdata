using Microsoft.AspNet.SignalR.Client;
using ProtoBuf;
using SSI.TradingAPI.Client;
using SSI.TradingAPI.Event.Notify;
using System;
using System.Collections.Generic;
using System.IO;

namespace SSI.FastConnect.RealTimeClient
{
    public delegate void NotifyDelegate(NotifyEvent @event);
    public class TradingStreamingClient : IDisposable
    {
        private readonly HubConnection _hub;

        readonly Dictionary<Type, List<Delegate>> _dicDelegate = new Dictionary<Type, List<Delegate>>();
        private event NotifyDelegate NotifyDelegate; 
        private event StateChangeDelegate _onStateChange;
        public TradingStreamingClient(string host, string consumerId, string consumerSecret, string hubName, string eventName)
        {
            _hub = new HubConnection(host);
            _hub.StateChanged += _hub_StateChanged;
            _hub.Headers.Add("ConsumerId", consumerId);
            _hub.Headers.Add("ConsumerSecret", consumerSecret);
            var hubProxy = _hub.CreateHubProxy(hubName);
            hubProxy.On(eventName, OnMessage);
        }
        public void OnStateChange(StateChangeDelegate stateChange)
        {
            _onStateChange += stateChange;
        }
        private void _hub_StateChanged(Microsoft.AspNet.SignalR.Client.StateChange obj)
        {
            try
            {
                var oldVal = (ConnectionState)obj.OldState;
                var newVal = (ConnectionState)obj.NewState;
                StateChange stateChange = new StateChange(oldVal, newVal);
                _onStateChange?.Invoke(stateChange);
            }
            catch (Exception ex)
            {
                // Do anything
            }
        }

        public bool Start()
        {
            if (_hub == null)
            {
                return false;
            }

            _hub.Start();
            return true;
        }

        private void OnMessage(dynamic data)
        {
            var buffer = Convert.FromBase64String(data as string);
            var x = ProtoDeserialize<NotifyEvent>(buffer);
            if (_dicDelegate.ContainsKey(x.GetType()))
            {
                var list = _dicDelegate[x.GetType()];
                foreach (var item in list)
                {
                    item.DynamicInvoke(x);
                }
            }
            NotifyDelegate?.Invoke(x);
        }

        public void Subscribe<T>(SubcribeDelegate<T> del)
            where T : NotifyEvent
        {
            if (!_dicDelegate.ContainsKey(typeof(T)))
            {
                _dicDelegate.Add(typeof(T), new List<Delegate>());
            }
            _dicDelegate[typeof(T)].Add(Delegate.CreateDelegate(del.GetType(), del.Target, del.Method));
        }
        public void SubscribeAll(NotifyDelegate notify)
        {
            NotifyDelegate += notify;
        }

        private T ProtoDeserialize<T>(byte[] data)
        {
            if (null == data)
            {
                return default(T);
            }
            using (var stream = new MemoryStream(data))
            {
                return Serializer.Deserialize<T>(stream);
            }
        }

        public void Dispose()
        {
            if (_hub != null)
                _hub.Dispose();
        }
    }
}
