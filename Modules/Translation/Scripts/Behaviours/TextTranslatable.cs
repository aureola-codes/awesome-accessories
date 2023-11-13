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

        [Header("Dependencies")]
        [SerializeField] private TranslationsObject _translations;

        [Header("Events")]
        [SerializeField] private LanguageChangedEvent _onLanguageChanged;

        private void Awake()
        {
            _textField = GetComponent<Text>();
            _translationKey = _textField.text;
        }

        private void OnEnable()
        {
            Render();

            _onLanguageChanged?.Subscribe(OnLanguageChanged);
        }

        private void OnDisable()
        {
            _onLanguageChanged?.Unsubscribe(OnLanguageChanged);
        }

        private void OnLanguageChanged(SystemLanguage language)
        {
            Render();
        }

        private void Render()
        {
            if (_translationKey == null || _translationKey == "") {
                Debug.LogWarning("Translation key is empty.");
                return;
            }

            _textField.text = _translations?.Get(_translationKey);
        }
    }
}
