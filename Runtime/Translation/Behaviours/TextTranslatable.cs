using Aureola.PubSub;
using UnityEngine;
using UnityEngine.UI;

namespace Aureola.Translation
{
    [RequireComponent(typeof(Text))]
    public class TextTranslatable : MonoBehaviour
    {
        private string _translationKey;
        private Text _textField;

        public bool autoUpdate = false;

        private void Awake()
        {
            _textField = GetComponent<Text>();
            _translationKey = _textField.text;
        }

        private void OnEnable()
        {
            Render();
            if (autoUpdate) {
                PubSubManager.instance?.Subscribe(Channel.TRANSLATION, typeof(LanguageChanged), OnLanguageChanged);
            }
        }

        private void OnDisable()
        {
            if (autoUpdate) {
                PubSubManager.instance?.Unsubscribe(Channel.TRANSLATION, typeof(LanguageChanged), OnLanguageChanged);
            }
        }

        private void OnLanguageChanged(IGameEvent gameEvent)
        {
            Render();
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
