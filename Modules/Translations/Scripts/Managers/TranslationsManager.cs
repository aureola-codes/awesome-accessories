using System.Collections.Generic;
using UnityEngine;

namespace Aureola.Translations
{
    [CreateAssetMenu(fileName = "TranslationManager", menuName = "Aureola/Translations/TranslationManager", order = 19)]
    public class TranslationsManager : ScriptableObject, IResettable, ILocatable
    {
        private Translation _translation;

        public delegate void Changed(Translation translation);
        public event Changed OnChanged;

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
            return _translations[0].Language;
        }

        public string GetCode() 
        {
            return _translation?.Code;
        }

        public SystemLanguage GetLanguage()
        {
            return _translation?.Language ?? SystemLanguage.Unknown;
        }

        public SystemLanguage? GetLanguageByCode(string code)
        {
            foreach (Translation translation in _translations) {
                if (translation.Code == code) {
                    return translation.Language;
                }
            }

            return null;
        }

        public string GetCodeByLanguage(SystemLanguage systemLanguage)
        {
            foreach (Translation translation in _translations) {
                if (translation.Language == systemLanguage) {
                    return translation.Code;
                }
            }

            return null;
        }

        public Dictionary<string, string> GetLanguageOptions()
        {
            Dictionary<string, string> options = new Dictionary<string, string>();
            foreach (Translation translation in _translations) {
                options.Add(translation.Code, translation.Label);
            }

            return options;
        }

        public bool IsSupported(SystemLanguage systemLanguage)
        {
            foreach (Translation translation in _translations) {
                if (translation.Language == systemLanguage) {
                    return true;
                }
            }

            return false;
        }

        public bool IsSupported(string code)
        {
            foreach (Translation translation in _translations) {
                if (translation.Code == code) {
                    return true;
                }
            }

            return false;
        }

        public void SetLanguage(SystemLanguage systemLanguage)
        {
            if (_translation?.Language == systemLanguage) {
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
                if (translation.Language == systemLanguage) {
                    return translation;
                }
            }

            return null;
        }

        public Translation GetTranslation(string code)
        {
            foreach (Translation translation in _translations) {
                if (translation.Code == code) {
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

            translation.OnLoaded += HandleSuccess;
            translation.OnError += HandleError;
            translation.Load();
        }

        private void HandleSuccess(Translation translation)
        {
            translation.OnLoaded -= HandleSuccess;
            translation.OnError -= HandleError;

            _translation = translation;
            OnChanged?.Invoke(_translation);
        }

        private void HandleError(Translation translation, string message)
        {
            translation.OnLoaded -= HandleSuccess;
            translation.OnError -= HandleError;

            Debug.LogError(message);
        }
    }
}
