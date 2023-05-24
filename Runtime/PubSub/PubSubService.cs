using System.Collections.Generic;
using UnityEngine;

namespace Aureola.PubSub
{
    public class PubSubService
    {
        private bool _debugging = false;
        private Dictionary<string, GameEventDelegate> _channels = new Dictionary<string, GameEventDelegate>();
        
        public delegate void GameEventDelegate(IGameEvent eventData);

        public PubSubService(bool debugging = false)
        {
            _debugging = debugging;
        }

        public bool Exists(string channelName)
        {
            return _channels.ContainsKey(channelName);
        }

        public void Subscribe(string channelName, GameEventDelegate callback)
        {
            if (Exists(channelName)) {
                _channels[channelName] += callback;
            } else {
                _channels.Add(channelName, callback);
            }
            
            if (_debugging) {
                Debug.Log(channelName + ": Listener added => " + callback);
            }
        }

        public void Unsubscribe(string channelName, GameEventDelegate callback)
        {
            if (Exists(channelName)) {
                _channels[channelName] -= callback;
            }

            if (_debugging) {
                Debug.Log(channelName + ": Listener removed " + callback);
            }
        }

        public void Send(string channelName, IGameEvent data)
        {
            if (Exists(channelName)) {
                _channels[channelName].Invoke(data);
            }

            if (_debugging) {
                Debug.Log(channelName + ": Event invoked => " + JsonUtility.ToJson(data));
            }
        }

        public void Publish(string channelName, IGameEvent data) => Send(channelName, data);

        public void Clear(string channelName)
        {
            _channels.Remove(channelName);
            if (_debugging) {
                Debug.Log(channelName + ": Channel removed.");
            }
        }

        public void Reset()
        {
            _channels = new Dictionary<string, GameEventDelegate>();
        }
    }
}
