using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Aureola.Translations
{
    [CreateAssetMenu(fileName = "Translation", menuName = "Aureola/Translations/Translation", order = 19)]
    public class Translation : ScriptableObject
    {
        private Dictionary<string, string> _translations = new Dictionary<string, string>();
        private bool _isLoaded = false;

        public delegate void Loaded(Translation translation);
        public event Loaded onLoaded;

        public delegate void Error(Translation translation, string message);
        public event Error onError;

        [Header("Settings")]
        [SerializeField] private string _code;
        [SerializeField] private string _label;
        [SerializeField] private SystemLanguage _systemLanguage;
        [SerializeField] private AssetReference _assetReference;

        public string code {
            get => _code;
        }

        public string label {
            get => _label;
        }

        public SystemLanguage systemLanguage {
            get => _systemLanguage;
        }

        public void Load()
        {
            if (_isLoaded) {
                HandleSuccess();
                return;
            }

            Addressables.LoadResourceLocationsAsync(_assetReference).Completed += checkAddressHandle => {
                if (checkAddressHandle.Result.Count == 0) {
                    HandleError("Failed to load language file: " + _assetReference);
                    return;
                }

                Addressables.LoadAssetAsync<TextAsset>(_assetReference).Completed += handle => {
                    if (handle.Status == AsyncOperationStatus.Succeeded) {
                        _translations = GetFileParser(handle.Result.text).Parse();
                        if (_translations.Count > 0) {
                            HandleSuccess();
                        } else {
                            HandleError("No translations found for: " + systemLanguage);
                        }
                    }
                    
                    Addressables.Release(handle);
                };
            };
        }

        public string Get(string key)
        {
            if (!_isLoaded) {
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
            if (!_isLoaded) {
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


        private void HandleSuccess()
        {
            _isLoaded = true;
            onLoaded?.Invoke(this);
        }

        private void HandleError(string message)
        {
            Debug.LogError(message);
            onError?.Invoke(this, message);
        }

        private IFileParser GetFileParser(string contents)
        {
            IFileParser fileParser = null;
            if (contents.Trim().StartsWith("{")) {
                fileParser = new JsonFileParser();      
            } else {
                fileParser = new CsvFileParser();
            }
            
            fileParser.SetContents(contents);
            return fileParser;
        }
    }
}
