using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Aureola.Translations
{
    [CreateAssetMenu(fileName = "TranslationManager", menuName = "Aureola/Translations/TranslationManager", order = 19)]
    public class TranslationsManager : ScriptableObject, IResettable
    {
        private Translation _translation;

        public delegate void OnChanged(Translation translation);
        public event OnChanged onChanged;

        [Header("Settings")]
        [SerializeField] private List<Translation> _translations;

        public string Get(string key)
        {
            if (_translation == null) {
                Debug.LogWarning("No translation active!");
                return key;
            }

            return _translation.Get(key);
        }

        public string Get(string key, Dictionary<string, string> replacements)
        {
            if (_translation == null) {
                Debug.LogWarning("No translation active!");
                return key;
            }

            return _translation.Get(key, replacements);
        }

        public SystemLanguage GetDefault()
        {
            return _translations[0].systemLanguage;
        }

        public string GetCode() 
        {
            return _translation?.code;
        }

        public SystemLanguage GetLanguage()
        {
            return _translation?.systemLanguage ?? SystemLanguage.Unknown;
        }

        public SystemLanguage? GetLanguageByCode(string code)
        {
            foreach (Translation translation in _translations) {
                if (translation.code == code) {
                    return translation.systemLanguage;
                }
            }

            return null;
        }

        public string GetCodeByLanguage(SystemLanguage systemLanguage)
        {
            foreach (Translation translation in _translations) {
                if (translation.systemLanguage == systemLanguage) {
                    return translation.code;
                }
            }

            return null;
        }

        public Dictionary<string, string> GetLanguageOptions()
        {
            Dictionary<string, string> options = new Dictionary<string, string>();
            foreach (Translation translation in _translations) {
                options.Add(translation.code, translation.label);
            }

            return options;
        }

        public bool IsSupported(SystemLanguage systemLanguage)
        {
            foreach (Translation translation in _translations) {
                if (translation.systemLanguage == systemLanguage) {
                    return true;
                }
            }

            return false;
        }

        public bool IsSupported(string code)
        {
            foreach (Translation translation in _translations) {
                if (translation.code == code) {
                    return true;
                }
            }

            return false;
        }

        public void SetLanguage(SystemLanguage systemLanguage)
        {
            if (_translation?.systemLanguage == systemLanguage) {
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

        public Translation GetTranslation(SystemLanguage systemLanguage)
        {
            foreach (Translation translation in _translations) {
                if (translation.systemLanguage == systemLanguage) {
                    return translation;
                }
            }

            return null;
        }

        public void Reset()
        {
            _translation = null;
        }

        private void LoadLanguage(SystemLanguage systemLanguage)
        {
            var translation = GetTranslation(systemLanguage);
            if (translation == null) {
                Debug.LogError("Language not found: " + systemLanguage);
                return;
            }

            translation.onLoaded += HandleSuccess;
            translation.onError += HandleError;
            translation.Load();
        }

        private void HandleSuccess(Translation translation)
        {
            translation.onLoaded -= HandleSuccess;
            translation.onError -= HandleError;

            _translation = translation;
            onChanged?.Invoke(_translation);
        }

        private void HandleError(Translation translation, string message)
        {
            translation.onLoaded -= HandleSuccess;
            translation.onError -= HandleError;

            Debug.LogError(message);
        }
    }
}
