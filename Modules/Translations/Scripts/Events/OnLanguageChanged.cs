using Aureola.PubSub;

namespace Aureola.Translations
{
    public class OnLanguageChanged : IPubSubEvent
    {
        public readonly TranslationsManager manager;
        public OnLanguageChanged(TranslationsManager translationsManager)
        {
            manager = translationsManager;
        }
    }
}
