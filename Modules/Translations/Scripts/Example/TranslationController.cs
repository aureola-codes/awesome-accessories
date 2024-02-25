using Aureola.Translations;
using UnityEngine;

namespace Aureola.Examples
{
    public class TranslationController : MonoBehaviour
    {
        [Header("Dependencies")]
        [SerializeField] private TranslationsManager _translationsManager;

        private void Awake()
        {
            _translationsManager.SetLanguage(SystemLanguage.English);
        }

        public void SetLanguage(string language)
        {
            _translationsManager.SetLanguage(language);
        }
    }
}
