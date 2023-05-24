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
        private static TranslationService _instance;

        [System.Serializable]
        private class SupportedLanguage
        {
            public string code;
            public SystemLanguage language;
        }

        [Header("Settings")]
        [SerializeField] private string _basePath = "Assets/Translations";
        [SerializeField] private string _defaultLanguage = "EN";
        [SerializeField] private SupportedLanguage[] _supportedLanguages;

        public static TranslationService instance
        {
            get => _instance;
        }

        private void Awake()
        {
            _instance = new TranslationService(_basePath, _defaultLanguage);
            _instance.onUpdated += OnLanguageChanged;

             // Register all supported languages.
            foreach (var supportedLanguage in _supportedLanguages) {
                _instance.Register(supportedLanguage.code, supportedLanguage.language);
            }

            // Try to guess set user's preferred language.
            string language = SettingsManager.instance.Get("language", "");
            if (language != "") {
                _instance.ChangeLanguage(language);
            } else {
                _instance.ChangeLanguage(Application.systemLanguage);
            }
        }

        private void OnEnable()
        {
            PubSubManager.instance?.Subscribe(Channel.SETTINGS, OnSettingsEvent);
        }

        private void OnDisable()
        {
            PubSubManager.instance?.Unsubscribe(Channel.SETTINGS, OnSettingsEvent);
        }

        private void OnLanguageChanged(string language)
        {
            PubSubManager.instance?.Send(Channel.TRANSLATION, new LanguageChanged(language));
        }

        private void OnSettingsEvent(IGameEvent gameEvent)
        {
            if (gameEvent.GetType() == typeof(SettingsEvent)) {
                var settingsEvent = (SettingsEvent) gameEvent;
                var settingsData = (SettingsData) settingsEvent.settings;

                _instance.ChangeLanguage(settingsData.language);
            }
        }
    }
}
