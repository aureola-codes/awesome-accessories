using Aureola.PubSub;
using UnityEngine;
using TMPro;

namespace Aureola.Translation
{
    [RequireComponent(typeof(TMP_Text))]
    public class TMProTranslatable : MonoBehaviour
    {
        private string _translationKey;
        private TMP_Text _textField;

        public bool autoUpdate = false;

        private void Awake()
        {
            _textField = GetComponent<TMP_Text>();
            _translationKey = _textField.text;
        }

        private void OnEnable()
        {
            Render();
            if (autoUpdate) {
                PubSubManager.instance?.Subscribe(Channel.TRANSLATION, OnLanguageChanged);
            }
        }

        private void OnDisable()
        {
            if (autoUpdate) {
                PubSubManager.instance?.Unsubscribe(Channel.TRANSLATION, OnLanguageChanged);
            }
        }

        private void OnLanguageChanged(IGameEvent gameEvent)
        {
            if (gameEvent.GetType() == typeof(LanguageChanged)) {
                Render();
            }
        }

        private void Render()
        {
            if (_translationKey == null || _translationKey == "") {
                Debug.LogWarning("Translation key is empty.");
                return;
            }

            _textField.text = TranslationManager.instance?.Get(_translationKey);
        }
    }
}
