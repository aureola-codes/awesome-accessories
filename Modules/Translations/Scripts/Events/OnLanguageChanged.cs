using Aureola.PubSub;

namespace Aureola.Translations
{
    public class OnLanguageChanged : IEvent
    {
        public readonly TranslationsManager Manager;
        public OnLanguageChanged(TranslationsManager manager)
        {
            Manager = manager;
        }
    }
}
