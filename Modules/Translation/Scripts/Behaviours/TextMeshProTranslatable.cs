using UnityEngine;
using TMPro;

namespace Aureola.Translation
{
    [RequireComponent(typeof(TMP_Text))]
    public class TextMeshProTranslatable : MonoBehaviour
    {
        private string _translationKey;
        private TMP_Text _textField;

        [Header("Dependencies")]
        [SerializeField] private TranslationsObject _translations;

        [Header("Events")]
        [SerializeField] private LanguageChangedEvent _onLanguageChanged;

        private void Awake()
        {
            _textField = GetComponent<TMP_Text>();
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

            _textField.text = _translations.Get(_translationKey);
        }
    }
}
