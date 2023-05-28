using Aureola.PubSub;
using UnityEngine;
using TMPro;

namespace Aureola.Translation
{
    [RequireComponent(typeof(TMP_Text))]
    public class TextMeshProTranslatable : MonoBehaviour
    {
        private string _translationKey;
        private TMP_Text _textField;

        [Header("Settings")]
        [SerializeField] private bool _autoUpdate = false;

        private void Awake()
        {
            _textField = GetComponent<TMP_Text>();
            _translationKey = _textField.text;
        }

        private void OnEnable()
        {
            Render();
            if (_autoUpdate) {
                PubSubManager.instance?.Subscribe(Channel.TRANSLATION, typeof(LanguageChanged), OnLanguageChanged);
            }
        }

        private void OnDisable()
        {
            if (_autoUpdate) {
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
