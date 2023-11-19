using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Aureola.Translation
{
    [CreateAssetMenu(fileName = "TranslationManager", menuName = "Aureola/Translation/TranslationManager")]
    public class TranslationManager : ScriptableObject
    {
        [System.Serializable]
        private class Language
        {
            public string code;
            public string label;
            public SystemLanguage systemLanguage;
        }

        private SystemLanguage _language = SystemLanguage.Unknown;
        private Dictionary<string, string> _translations = new Dictionary<string, string>();

        public delegate void LanguageChanged(SystemLanguage language);
        public event LanguageChanged onLanguageChanged;

        [Header("Settings")]
        [SerializeField] private string _baseAddress = "Assets/Translations";
        [SerializeField] private List<Language> _languages = new List<Language>() {
            new Language() { code = "en", label = "English", systemLanguage = SystemLanguage.English }
        };

        public string Get(string key)
        {
            string value;
            if (_translations.TryGetValue(key, out value)) {
                return value;
            }

            Debug.LogWarning("Translation not found for: " + key);
            return key;
        }

        public string Get(string key, Dictionary<string, string> replacements)
        {
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

        public SystemLanguage GetDefault()
        {
            return _languages[0].systemLanguage;
        }

        public SystemLanguage GetLanguage()
        {
            return _language;
        }

        public SystemLanguage? GetLanguageByCode(string code)
        {
            foreach (Language language in _languages) {
                if (language.code == code) {
                    return language.systemLanguage;
                }
            }

            return null;
        }

        public string GetCodeByLanguage(SystemLanguage systemLanguage)
        {
            foreach (Language language in _languages) {
                if (language.systemLanguage == systemLanguage) {
                    return language.code;
                }
            }

            return null;
        }

        public Dictionary<string, string> GetLanguageOptions()
        {
            Dictionary<string, string> options = new Dictionary<string, string>();
            foreach (Language language in _languages) {
                options.Add(language.code, language.label);
            }

            return options;
        }

        public bool IsSupported(SystemLanguage systemLanguage)
        {
            foreach (Language language in _languages) {
                if (language.systemLanguage == systemLanguage) {
                    return true;
                }
            }

            return false;
        }

        public bool IsSupported(string code)
        {
            foreach (Language language in _languages) {
                if (language.code == code) {
                    return true;
                }
            }

            return false;
        }

        public void SetLanguage(SystemLanguage systemLanguage)
        {
            if (_language == systemLanguage) {
                Debug.LogWarning("Language already set: " + systemLanguage);
                return;
            }

            if (!IsSupported(systemLanguage)) {
                Debug.LogError("Language not supported: " + systemLanguage);
                return;
            }

            LoadLanguage(systemLanguage);
        }

        public void SetLanguage(string languageCode)
        {
            SystemLanguage? systemLanguage = GetLanguageByCode(languageCode);
            if (systemLanguage == null) {
                Debug.LogError("Language not supported: " + languageCode);
                return;
            }

            SetLanguage((SystemLanguage) systemLanguage);
        }

        private void LoadLanguage(SystemLanguage systemLanguage)
        {
            string languageAddress = GetLanguageAddress(systemLanguage);
            Addressables.LoadResourceLocationsAsync(languageAddress).Completed += checkAddressHandle => {
                if (checkAddressHandle.Result.Count == 0) {
                    Debug.LogError("Failed to load language file: " + languageAddress);
                    return;
                }

                Addressables.LoadAssetAsync<TextAsset>(languageAddress).Completed += handle => {
                    if (handle.Status == AsyncOperationStatus.Succeeded) {
                        var translations = GetFileParser(handle.Result.text).Parse();
                        if (translations.Count > 0) {
                            _language = systemLanguage;
                            _translations = translations;

                            onLanguageChanged?.Invoke(_language);
                        } else {
                            Debug.LogError("No translations found for: " + systemLanguage);
                        }
                    }
                    
                    Addressables.Release(handle);
                };
            };
        }

        private string GetLanguageAddress(SystemLanguage language)
        {
            return _baseAddress + "/" + GetCodeByLanguage(language);
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
