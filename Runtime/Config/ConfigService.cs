using SimpleJSON;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Aureola.Accessories
{
    public class ConfigService
    {
        private Dictionary<string, float> _floatValues = new Dictionary<string, float>();
        private Dictionary<string, string> _stringValues = new Dictionary<string, string>();

        public void Load(AssetReference configFile, bool clear = false)
        {
            if (clear) {
                Clear();
            }

            configFile.LoadAssetAsync<TextAsset>().Completed += handle => {
                var jsonObject = JSON.Parse(handle.Result.text);
                foreach (var keyValuePair in jsonObject) {
                    if (keyValuePair.Value.IsString) {
                        _stringValues.Add(keyValuePair.Key, keyValuePair.Value);
                    } else if (keyValuePair.Value.IsNumber) {
                        _floatValues.Add(keyValuePair.Key, keyValuePair.Value);
                    } else {
                        Debug.LogWarning("Config value not supported: " + keyValuePair.Value);
                    }
                }

                Addressables.Release(handle);
            };
        }

        public void Set(string key, float value)
        {
            _floatValues[key] = value;
        }

        public void Set(string key, string value)
        {
            _stringValues[key] = value;
        }

        public float Get(string key, float defaultValue)
        {
            float value;
            if (_floatValues.TryGetValue(key, out value)) {
                return value;
            }

            Debug.LogWarning("Configuration value not found: " + key);
            return defaultValue;
        }

        public string Get(string key, string defaultValue)
        {
            string value;
            if (_stringValues.TryGetValue(key, out value)) {
                return value;
            }

            Debug.LogWarning("Configuration value not found: " + key);
            return defaultValue;
        }

        public void Clear()
        {
            _floatValues = new Dictionary<string, float>();
            _stringValues = new Dictionary<string, string>();
        }
    }
}
