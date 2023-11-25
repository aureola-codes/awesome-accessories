using SimpleJSON;
using System.Collections.Generic;
using UnityEngine;

namespace Aureola.Settings
{
    public class SettingsData
    {
        private Dictionary<string, object> _data = new Dictionary<string, object>();

        public static SettingsData FromJson(string json)
        {
            var jsonObject = JSON.Parse(json);

            var settings = new SettingsData();
            foreach (var field in typeof(SettingsData).GetFields()) {
                if (jsonObject[field.Name] == null) {
                    continue;
                }

                if (field.FieldType == typeof(int)) {
                    settings.Set(field.Name, jsonObject[field.Name].AsInt);
                }
                else if (field.FieldType == typeof(float)) {
                    settings.Set(field.Name, jsonObject[field.Name].AsFloat);
                }
                else if (field.FieldType == typeof(string)) {
                    settings.Set(field.Name, jsonObject[field.Name].Value);
                }
                else if (field.FieldType == typeof(bool)) {
                    settings.Set(field.Name, jsonObject[field.Name].AsBool);
                }
            }

            return settings;
        }

        public string ToJson()
        {
            var jsonObject = new JSONObject();
            foreach (var entry in _data) {
                if (entry.Value is int) {
                    jsonObject.Add(entry.Key, new JSONNumber((int) entry.Value));
                }
                else if (entry.Value is float) {
                    jsonObject.Add(entry.Key, new JSONNumber((float) entry.Value));
                }
                else if (entry.Value is string) {
                    jsonObject.Add(entry.Key, new JSONString((string) entry.Value));
                }
                else if (entry.Value is bool) {
                    jsonObject.Add(entry.Key, new JSONBool((bool) entry.Value));
                }
            }

            return jsonObject.ToString();
        }

        public void Set(string key, object value)
        {
            _data[key] = value;
        }

        public string Get(string key, string defaultValue)
        {
            if (!_data.ContainsKey(key)) {
                return defaultValue;
            }

            if (!(_data[key] is string)) {
                Debug.LogWarning($"SettingsData: {key} is not a string.");
                return defaultValue;
            }

            return (string) _data[key];
        }

        public int Get(string key, int defaultValue)
        {
            if (!_data.ContainsKey(key)) {
                return defaultValue;
            }

            if (!(_data[key] is int)) {
                Debug.LogWarning($"SettingsData: {key} is not a integer.");
                return defaultValue;
            }

            return (int) _data[key];
        }

        public float Get(string key, float defaultValue)
        {
            if (!_data.ContainsKey(key)) {
                return defaultValue;
            }

            if (!(_data[key] is float)) {
                Debug.LogWarning($"SettingsData: {key} is not a number.");
                return defaultValue;
            }

            return (float) _data[key];
        }

        public bool Get(string key, bool defaultValue)
        {
            if (!_data.ContainsKey(key)) {
                return defaultValue;
            }

            if (!(_data[key] is bool)) {
                Debug.LogWarning($"SettingsData: {key} is not a boolean.");
                return defaultValue;
            }

            return (bool) _data[key];
        }
    }
}
