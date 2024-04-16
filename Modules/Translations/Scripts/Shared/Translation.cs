using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Aureola.Translations
{
    [CreateAssetMenu(fileName = "Translation", menuName = "Aureola/Translation", order = 51)]
    public class Translation : ScriptableObject, IResettable
    {
        [System.Serializable]
        public struct LanguageFile
        {
            public string prefix;
            public AssetReference assetReference;
        }

        private Dictionary<string, string> _translations = new Dictionary<string, string>();
        private int _numLoaded = 0;
        private int _numTotal = 0;

        public delegate void Loaded(Translation translation);
        public event Loaded OnLoaded;

        public delegate void Error(Translation translation, string message);
        public event Error OnError;

        [Header("Settings")]
        [SerializeField] private string _code;
        [SerializeField] private string _label;
        [SerializeField] private SystemLanguage _systemLanguage;
        [SerializeField] private List<LanguageFile> _languageFiles;

        public string code {
            get => _code;
        }

        public string label {
            get => _label;
        }

        public SystemLanguage language {
            get => _systemLanguage;
        }

        public bool isLoaded {
            get => _numTotal > 0 && _numTotal == _numLoaded;
        }

        public void Load()
        {
            if (isLoaded) {
                HandleSuccess();
                return;
            }

            if (_languageFiles.Count == 0) {
                HandleError("No language files found for: " + language);
                return;
            }

            _numTotal = _languageFiles.Count;
            foreach (var languageFile in _languageFiles) {
                Addressables.LoadAssetAsync<TextAsset>(languageFile.assetReference).Completed += handle => {
                    if (handle.Status == AsyncOperationStatus.Succeeded) {
                        var prefix = languageFile.prefix;
                        if (prefix != string.Empty && !prefix.Contains(".")) {
                            prefix += ".";
                        }

                        var translations = GetParser(handle.Result.text).Parse(handle.Result.text);
                        foreach (var keyValuePair in translations) {
                            _translations[prefix + keyValuePair.Key] = keyValuePair.Value;
                        }

                        _numLoaded++;
                        if (_numLoaded == _numTotal) {
                            HandleSuccess();
                        }
                    } else {
                        HandleError("Failed to load translation: " + languageFile.assetReference);
                    }
                    
                    Addressables.Release(handle);
                };
            }
        }

        public string Get(string key)
        {
            if (!isLoaded) {
                Debug.LogWarning("Translation not loaded!");
                return key;
            }

            string value;
            if (_translations.TryGetValue(key, out value)) {
                return value;
            }

            Debug.LogWarning("Translation not found for: " + key);
            return key;
        }

        public string Get(string key, Dictionary<string, string> replacements)
        {
            if (!isLoaded) {
                Debug.LogWarning("Translation not loaded!");
                return key;
            }

            string value;
            if (_translations.TryGetValue(key, out value)) {
                foreach (var keyValuePair in replacements) {
                    value = value.Replace(":" + keyValuePair.Key, keyValuePair.Value);
                }

                return value;
            }

            Debug.LogWarning("Translation not found for: " + key);
            return key;
        }

        public void Reset()
        {
            _translations.Clear();
            _numLoaded = 0;
        }

        private void HandleSuccess()
        {
            OnLoaded?.Invoke(this);
        }

        private void HandleError(string message)
        {
            Debug.LogError(message);
            OnError?.Invoke(this, message);
        }

        private IParser GetParser(string contents)
        {
            string trimmedContents = contents.Trim();
            if (trimmedContents.StartsWith("{") || trimmedContents.StartsWith("[")) {
                return new JsonParser();
            }
            else if (trimmedContents.Contains(",") && (trimmedContents.StartsWith("\"") || trimmedContents.Split('\n')[0].Count(c => c == ',') > 0)) {
                return new CSVParser();
            }
            else if (trimmedContents.Contains(":") && !trimmedContents.StartsWith("#") && (trimmedContents.Contains("\n") || trimmedContents.Contains(": "))) {
                return new YamlParser();
            } 
            else {
                return new TextParser();
            }
        }
    }
}
