using Aureola.PubSub;

namespace Aureola.Translations
{
    public class OnLanguageChanged : IPubSubEvent
    {
        public readonly TranslationsManager Manager;
        public OnLanguageChanged(TranslationsManager manager)
        {
            Manager = manager;
        }
    }
}
