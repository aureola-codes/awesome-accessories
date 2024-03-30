using Aureola.PubSub;
using System.Collections.Generic;
using UnityEngine;

namespace Aureola.Translations
{
    [CreateAssetMenu(fileName = "TranslationManager", menuName = "Aureola/TranslationManager", order = 50)]
    public class TranslationsManager : ScriptableObject, IResettable, ILocatable
    {
        private Translation _translation;

        public delegate void Changed(Translation translation);
        public event Changed OnChanged;

        [Header("Settings")]
        [SerializeField] private List<Translation> _translations;

        [Header("Dependencies (optional)")]
        [SerializeField] private PubSubManager _pubSubManager;

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
            return _translations[0].language;
        }

        public string GetCode() 
        {
            return _translation?.code;
        }

        public SystemLanguage GetLanguage()
        {
            return _translation?.language ?? SystemLanguage.Unknown;
        }

        public SystemLanguage? GetLanguageByCode(string code)
        {
            foreach (Translation translation in _translations) {
                if (translation.code == code) {
                    return translation.language;
                }
            }

            return null;
        }

        public string GetCodeByLanguage(SystemLanguage systemLanguage)
        {
            foreach (Translation translation in _translations) {
                if (translation.language == systemLanguage) {
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
                if (translation.language == systemLanguage) {
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
            if (_translation?.language == systemLanguage) {
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
                if (translation.language == systemLanguage) {
                    return translation;
                }
            }

            return null;
        }

        public Translation GetTranslation(string code)
        {
            foreach (Translation translation in _translations) {
                if (translation.code == code) {
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
            if (_pubSubManager != null) {
                _pubSubManager.Publish(new OnLanguageChanged(this));
            }
        }

        private void HandleError(Translation translation, string message)
        {
            translation.OnLoaded -= HandleSuccess;
            translation.OnError -= HandleError;

            Debug.LogError(message);
        }
    }
}
