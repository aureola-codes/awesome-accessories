using System.Collections.Generic;
using UnityEngine;

namespace Aureola.PubSub
{
    [CreateAssetMenu(fileName = "PubSubManager", menuName = "Aureola/PubSubManager", order = 16)]
    public class PubSubManager : ScriptableObject, IResettable, ILocatable
    {
        public delegate void Event(IPubSubEvent channelEvent);

        private const string DEFAULT_CHANNEL = "Default";
        private Dictionary<string, Event> _channels;

        public void Publish(IPubSubEvent channelEvent)
        {
            Publish(DEFAULT_CHANNEL, channelEvent);
        }

        public void Publish(string channel, IPubSubEvent channelEvent)
        {
            if (_channels.TryGetValue(channel, out var subscriptions)) {
                subscriptions?.Invoke(channelEvent);
            }
        }

        public void Subscribe(Event callback)
        {
            Subscribe(DEFAULT_CHANNEL, callback);
        }

        public void Subscribe(string channel, Event callback)
        {
            if (!_channels.ContainsKey(channel)) {
                _channels.Add(channel, null);
            }

            _channels[channel] += callback;
        }

        public void Unsubscribe(Event callback)
        {
            Unsubscribe(DEFAULT_CHANNEL, callback);
        }

        public void Unsubscribe(string channel, Event callback)
        {
            if (_channels.ContainsKey(channel)) {
                _channels[channel] -= callback;
            }
        }

        public void ClearChannel(string channel)
        {
            if (_channels.ContainsKey(channel)) {
                _channels.Remove(channel);
            }
        }

        public void Reset()
        {
            _channels = new Dictionary<string, Event>();
        }
    }
}
