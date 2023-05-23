using Aureola.Storage;
using SimpleJSON;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Aureola.Config
{
    public class ConfigService : IStorageService
    {
        private IStorageService _storage;

        public ConfigService(IStorageService storage)
        {
            _storage = storage;
        }

        public void Load(AssetReference configFile)
        {
            configFile.LoadAssetAsync<TextAsset>().Completed += handle => {
                var jsonObject = JSON.Parse(handle.Result.text);
                foreach (var keyValuePair in jsonObject) {
                    var type = keyValuePair.Value.GetType().ToString().ToLower();
                    switch (type) {
                        case "int":
                            Set(keyValuePair.Key, (int) keyValuePair.Value);
                            break;
                        case "float":
                            Set(keyValuePair.Key, (float) keyValuePair.Value);
                            break;
                        case "string":
                            Set(keyValuePair.Key, (string) keyValuePair.Value);
                            break;
                        case "bool":
                            Set(keyValuePair.Key, (bool) keyValuePair.Value);
                            break;
                        case "vector2":
                            Set(keyValuePair.Key, (Vector2) keyValuePair.Value);
                            break;
                        case "vector3":
                            Set(keyValuePair.Key, (Vector3) keyValuePair.Value);
                            break;
                        case "vector4":
                            Set(keyValuePair.Key, (Vector4) keyValuePair.Value);
                            break;
                        case "quaternion":
                            Set(keyValuePair.Key, (Quaternion) keyValuePair.Value);
                            break;
                        case "color":
                            Set(keyValuePair.Key, (Color) keyValuePair.Value);
                            break;
                        case "color32":
                            Set(keyValuePair.Key, (Color32) keyValuePair.Value);
                            break;
                    }
                }

                Addressables.Release(handle);
            };
        }

        public void Load(AssetReference configFile, bool clearBeforeLoad)
        {
            if (clearBeforeLoad) {
                Clear();
            }

            Load(configFile);
        }

        public void Set(string key, float value) => _storage.Set(key, value);
        public void Set(string key, string value) => _storage.Set(key, value);
        public void Set(string key, int value) => _storage.Set(key, value);
        public void Set(string key, bool value) => _storage.Set(key, value);
        public void Set(string key, Vector2 value) => _storage.Set(key, value);
        public void Set(string key, Vector3 value) => _storage.Set(key, value);
        public void Set(string key, Vector4 value) => _storage.Set(key, value);
        public void Set(string key, Quaternion value) => _storage.Set(key, value);
        public void Set(string key, Color value) => _storage.Set(key, value);
        public void Set(string key, Color32 value) => _storage.Set(key, value);

        public float Get(string key, float defaultValue) => _storage.Get(key, defaultValue);
        public string Get(string key, string defaultValue) => _storage.Get(key, defaultValue);
        public int Get(string key, int defaultValue) => _storage.Get(key, defaultValue);
        public bool Get(string key, bool defaultValue) => _storage.Get(key, defaultValue);
        public Vector2 Get(string key, Vector2 defaultValue) => _storage.Get(key, defaultValue);
        public Vector3 Get(string key, Vector3 defaultValue) => _storage.Get(key, defaultValue);
        public Vector4 Get(string key, Vector4 defaultValue) => _storage.Get(key, defaultValue);
        public Quaternion Get(string key, Quaternion defaultValue) => _storage.Get(key, defaultValue);
        public Color Get(string key, Color defaultValue) => _storage.Get(key, defaultValue);
        public Color32 Get(string key, Color32 defaultValue) => _storage.Get(key, defaultValue);

        public void Clear() => _storage.Clear();
    }
}
