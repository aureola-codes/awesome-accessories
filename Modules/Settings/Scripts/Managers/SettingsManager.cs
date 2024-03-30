using Aureola.PubSub;
using UnityEngine;

namespace Aureola.Settings
{
    [CreateAssetMenu(fileName = "SettingsManager", menuName = "Aureola/SettingsManager", order = 20)]
    public class SettingsManager : ScriptableObject, IResettable, ILocatable
    {
        private bool _isReady = false;
        private SettingsData _settings = new SettingsData();

        public delegate void SettingsChanged();
        public event SettingsChanged OnChanged;

        public delegate void SettingsLoaded();
        public event SettingsLoaded OnLoaded;

        public delegate void SettingsStored();
        public event SettingsStored OnStored;

        public delegate void SettingsError(string message);
        public event SettingsError OnError;

        [Header("Dependencies")]
        [SerializeField] private BaseSettingsDriver _driver;

        [Header("Dependencies (optional)")]
        [SerializeField] private PubSubManager _pubSubManager;

        public bool isReady
        {
            get => _isReady;
        }

        public SettingsData data
        {
            get => _settings;
        }

        public void Load()
        {
            _isReady = false;

            _driver.Reset();
            _driver.OnError += (message) => {
                OnError?.Invoke(message);
                if (_pubSubManager != null) {
                    _pubSubManager.Publish(new OnSettingsError(this, message));
                }
            };
            _driver.OnLoaded += (settings) => {
                _settings = settings;
                _isReady = true;

                OnLoaded?.Invoke();
                if (_pubSubManager != null) {
                    _pubSubManager.Publish(new OnSettingsLoaded(this));
                }
            };

            _driver.Load();
        }

        public void Save()
        {
            _driver.Reset();
            _driver.OnError += (message) => {
                OnError?.Invoke(message);
                if (_pubSubManager != null) {
                    _pubSubManager.Publish(new OnSettingsError(this, message));
                }
            };
            _driver.OnStored += (settings) => {
                OnStored?.Invoke();
                if (_pubSubManager != null) {
                    _pubSubManager.Publish(new OnSettingsStored(this));
                }
            };

            _driver.Save(_settings);
        }

        public void Reset()
        {
            _isReady = false;
            _settings = new SettingsData();

            OnChanged?.Invoke();
            if (_pubSubManager != null) {
                _pubSubManager.Publish(new OnSettingsChanged(this));
            }
        }

        public void Set<T>(string key, T value)
        {
            if (_settings.Get<T>(key).Equals(value)) {
                return;
            }

            _settings.Set(key, value);

            OnChanged?.Invoke();
            if (_pubSubManager != null) {
                _pubSubManager.Publish(new OnSettingsChanged(this));
            }
        }

        public T Get<T>(string key)
        {
            return _settings.Get<T>(key);
        }
    }
}
