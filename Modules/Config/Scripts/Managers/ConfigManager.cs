using Aureola.AwesomeAccessories.SimpleJSON;
using Aureola.PubSub;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Aureola.Config
{
    [CreateAssetMenu(fileName = "ConfigManager", menuName = "Aureola/ConfigManager", order = 3)]
    public class ConfigManager : ScriptableObject, ILocatable
    {
        private bool _isLoaded = false;

        private RuntimeCacheDriver _storage;
        private RuntimeCacheDriver Storage
        {
            get
            {
                if (_storage == null) {
                    _storage = CreateInstance<RuntimeCacheDriver>();
                }

                return _storage;
            }
        }

        public delegate void Loaded();
        public Loaded OnLoaded;

        public bool IsLoaded => _isLoaded;

        [Header("Settings")]
        [SerializeField] private AssetReference _configFile;

        [Header("Dependencies (optional)")]
        [SerializeField] private PubSubManager _pubSubManager;

        public void Load()
        {
            _configFile.LoadAssetAsync<TextAsset>().Completed += handle => {
                var jsonObject = JSON.Parse(handle.Result.text);
                foreach (var keyValuePair in jsonObject) {
                    var type = keyValuePair.Value.GetType().ToString().ToLower();
                    switch (type) {
                        case "aureola.awesomeaccessories.simplejson.jsonnumber":
                            if (keyValuePair.Value.ToString().Contains(".")) {
                                Storage.Set(keyValuePair.Key, (float) keyValuePair.Value);
                            } else {
                                Storage.Set(keyValuePair.Key, (int) keyValuePair.Value);
                            }
                            break;
                        case "aureola.awesomeaccessories.simplejson.jsonstring":
                            if (IsHexColorString((string) keyValuePair.Value)) {
                                Storage.Set(keyValuePair.Key, HexToColor((string) keyValuePair.Value));
                            } else if (IsRgbaColorString((string) keyValuePair.Value)) {
                                Storage.Set(keyValuePair.Key, RgbaToColor((string) keyValuePair.Value));
                            } else {
                                Storage.Set(keyValuePair.Key, (string) keyValuePair.Value);
                            }
                            break;
                        case "aureola.awesomeaccessories.simplejson.jsonbool":
                            Storage.Set(keyValuePair.Key, (bool) keyValuePair.Value);
                            break;
                        case "aureola.awesomeaccessories.simplejson.jsonarray":
                            if (keyValuePair.Value.Count == 2) {
                                Storage.Set(keyValuePair.Key, new Vector2(keyValuePair.Value[0], keyValuePair.Value[1]));
                            } else if (keyValuePair.Value.Count == 3) {
                                Storage.Set(keyValuePair.Key, new Vector3(keyValuePair.Value[0], keyValuePair.Value[1], keyValuePair.Value[2]));
                            } else if (keyValuePair.Value.Count == 4) {
                                Storage.Set(keyValuePair.Key, new Quaternion(keyValuePair.Value[0], keyValuePair.Value[1], keyValuePair.Value[2], keyValuePair.Value[3]));
                            } else {
                                Debug.LogWarning("Unknown array type: " + keyValuePair.Value.ToString());
                            }
                            break;
                        case "aureola.awesomeaccessories.simplejson.jsonobject":
                            if (IsColor(keyValuePair.Value)) {
                                Storage.Set(keyValuePair.Key, new Color(
                                    (byte) keyValuePair.Value["r"], 
                                    (byte) keyValuePair.Value["g"], 
                                    (byte) keyValuePair.Value["b"], 
                                    (byte) keyValuePair.Value["a"]
                                ));
                            } else if (IsVector2(keyValuePair.Value)) {
                                Storage.Set(keyValuePair.Key, new Vector2(keyValuePair.Value["x"], keyValuePair.Value["y"]));
                            } else if (IsVector3(keyValuePair.Value)) {
                                Storage.Set(keyValuePair.Key, new Vector3(keyValuePair.Value["x"], keyValuePair.Value["y"], keyValuePair.Value["z"]));
                            } else if (IsQuaternion(keyValuePair.Value)) {
                                Storage.Set(keyValuePair.Key, new Quaternion(keyValuePair.Value["x"], keyValuePair.Value["y"], keyValuePair.Value["z"], keyValuePair.Value["w"]));
                            } else {
                                Debug.LogWarning("Unknown object type: " + keyValuePair.Value.ToString());
                            }
                            break;
                        default:
                            Debug.LogWarning("Unknown type: " + type);
                            break;
                    }
                }

                _isLoaded = true;

                Addressables.Release(handle);
                OnLoaded?.Invoke();
                if (_pubSubManager != null) {
                    _pubSubManager.Publish(new OnConfigLoaded(this));
                }
            };
        }

        public void Load(bool clearBeforeLoad)
        {
            if (clearBeforeLoad) {
                Clear();
            }

            Load();
        }

        public T Get<T>(string key) => Storage.Get<T>(key);
        public float Get(string key, float defaultValue) => Storage.Get(key, defaultValue);
        public string Get(string key, string defaultValue) => Storage.Get(key, defaultValue);
        public int Get(string key, int defaultValue) => Storage.Get(key, defaultValue);
        public bool Get(string key, bool defaultValue) => Storage.Get(key, defaultValue);
        public Vector2 Get(string key, Vector2 defaultValue) => Storage.Get(key, defaultValue);
        public Vector3 Get(string key, Vector3 defaultValue) => Storage.Get(key, defaultValue);
        public Vector4 Get(string key, Vector4 defaultValue) => Storage.Get(key, defaultValue);
        public Quaternion Get(string key, Quaternion defaultValue) => Storage.Get(key, defaultValue);
        public Color Get(string key, Color defaultValue) => Storage.Get(key, defaultValue);
        public Color32 Get(string key, Color32 defaultValue) => Storage.Get(key, defaultValue);
        public void Clear()
        {
            _isLoaded = false;
            Storage.Clear();
        }

        private bool IsVector2(JSONNode jsonNode)
        {
            return jsonNode.Count == 2 && jsonNode["x"] != null && jsonNode["y"] != null;
        }

        private bool IsVector3(JSONNode jsonNode)
        {
            return jsonNode.Count == 3 && jsonNode["x"] != null && jsonNode["y"] != null && jsonNode["z"] != null;
        }

        private bool IsQuaternion(JSONNode jsonNode)
        {
            return jsonNode.Count == 4 && jsonNode["x"] != null && jsonNode["y"] != null && jsonNode["z"] != null && jsonNode["w"] != null;
        }

        private bool IsColor(JSONNode jsonNode)
        {
            return jsonNode.Count == 4 && jsonNode["r"] != null && jsonNode["g"] != null && jsonNode["b"] != null && jsonNode["a"] != null;
        }

        private bool IsHexColorString(string value)
        {
            return value.StartsWith("#") && (value.Length == 7);
        }

        private bool IsRgbaColorString(string value)
        {
            return value.StartsWith("rgba(") && value.EndsWith(")");
        }

        private Color HexToColor(string hex)
        {
            if (ColorUtility.TryParseHtmlString(hex, out var color)) {
                return color;
            }

            return Color.white;
        }

        private Color RgbaToColor(string rgba)
        {
            var values = rgba.Replace("rgba(", "").Replace(")", "").Split(',');
            if (values.Length == 4) {
                return new Color(
                    float.Parse(values[0]) / 255f,
                    float.Parse(values[1]) / 255f,
                    float.Parse(values[2]) / 255f,
                    float.Parse(values[3]) / 255f
                );
            }

            return Color.white;
        }
    }
}
