using Aureola.PubSub;
using Aureola.Settings;
using SimpleJSON;
using System.Collections.Generic;
using UnityEngine.AddressableAssets;
using UnityEngine;

namespace Aureola.Translation
{
    public class TranslationManager : MonoBehaviour
    {
        private static TranslationService _service;

        [System.Serializable]
        private class SupportedLanguage
        {
            public string code;
            public SystemLanguage language;
        }

        [Header("Settings")]
        [SerializeField] private string _basePath = "Assets/Translations";
        [SerializeField] private bool _autoLoad = true;
        [SerializeField] private string _defaultLanguage = "";
        [SerializeField] private SupportedLanguage[] _supportedLanguages;

        public static TranslationService service
        {
            get => _service;
        }

        private void Awake()
        {
            _service = new TranslationService(_basePath);
            _service.onUpdated += OnLanguageChanged;

             // Register all supported languages.
            foreach (var supportedLanguage in _supportedLanguages) {
                _service.Register(supportedLanguage.code, supportedLanguage.language);
            }

            // Try to guess & set user's preferred language.
            if (_autoLoad) {
                string language = SettingsManager.service?.Get("language", _defaultLanguage);
                if (language != "") {
                    _service.ChangeLanguage(language);
                } else {
                    _service.ChangeLanguage(Application.systemLanguage);
                }
            }
        }

        private void OnEnable()
        {
            PubSubManager.service?.Subscribe(Channel.SETTINGS, typeof(SettingsUpdated), OnSettingsUpdated);
        }

        private void OnDisable()
        {
            PubSubManager.service?.Unsubscribe(Channel.SETTINGS, typeof(SettingsUpdated), OnSettingsUpdated);
        }

        private void OnLanguageChanged(string language)
        {
            PubSubManager.service?.Send(Channel.TRANSLATION, new LanguageChanged(language));
        }

        private void OnSettingsUpdated(IGameEvent gameEvent)
        {
            var SettingsUpdated = (SettingsUpdated) gameEvent;
            var settingsData = (SettingsData) SettingsUpdated.settings;

            _service.ChangeLanguage(settingsData.language);
        }
    }
}
