using Aureola.PubSub;
using Aureola.Settings;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Aureola.Translation
{
    public class TranslationService
    {
        private string _baseAddress;
        private string _language;
        private Dictionary<string, SystemLanguage> _languages = new Dictionary<string, SystemLanguage>();
        private Dictionary<string, string> _translations = new Dictionary<string, string>();

        public string language
        {
            get => _language;
        }

        public TranslationService(string baseAddress)
        {
            _baseAddress = baseAddress;
        }

        public TranslationService(string baseAddress, string defaultLanguage)
        {
            _baseAddress = baseAddress;
            ChangeLanguage(defaultLanguage);
        }

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

        public void Register(string languageId, SystemLanguage systemLanguage)
        {
            _languages[languageId] = systemLanguage;
        }

        public void Remove(string languageId)
        {
            _languages.Remove(languageId);
        }

        public bool IsRegistered(SystemLanguage systemLanguage)
        {
            return _languages.ContainsValue(systemLanguage);
        }

        public bool IsRegistered(string language)
        {
            return _languages.ContainsKey(language);
        }

        public void ChangeLanguage(SystemLanguage systemLanguage)
        {
            string language = LanguageToString(systemLanguage);
            if (language != _language) {
                SetLanguage(language);
            }
        }

        public void ChangeLanguage(string language)
        {
            if (language != _language) {
                SetLanguage(language);
            }
        }

        public string LanguageToString(SystemLanguage systemLanguage)
        {
            foreach (var keyValuePair in _languages) {
                if (keyValuePair.Value == systemLanguage) {
                    return keyValuePair.Key;
                }
            }

            Debug.LogError("Language not found: " + systemLanguage);
            return "EN";
        }

        public SystemLanguage StringToLanguage(string language)
        {
            SystemLanguage systemLanguage;
            if (_languages.TryGetValue(language, out systemLanguage)) {
                return systemLanguage;
            }

            Debug.LogError("Language not found: " + language);
            return SystemLanguage.English;
        }

        private void SetLanguage(string language)
        {
            _language = language;
            LoadLanguage();
        }

        private void LoadLanguage()
        {
            string languageAddress = GetLanguageAddress(_language);
            Addressables.LoadAssetAsync<TextAsset>(languageAddress).Completed += handle => {
                if (handle.Status == AsyncOperationStatus.Succeeded) {
                    var translations = GetFileParser(handle.Result.text).Parse();
                    if (translations.Count > 0) {
                        _translations = translations;

                        PubSubManager.instance?.Send(Channel.TRANSLATION, new TranslationEvent(_language));
                    } else {
                        Debug.LogError("No translations found for: " + _language);
                    }
                }
                
                Addressables.Release(handle);
            };
        }

        private string GetLanguageAddress(string language)
        {
            return _baseAddress + "/" + language.ToUpper();
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
