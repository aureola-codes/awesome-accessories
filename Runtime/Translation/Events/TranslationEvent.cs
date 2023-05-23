using Aureola.PubSub;

namespace Aureola.Translation
{
    public class TranslationEvent : IGameEvent
    {
        public string language;
        public TranslationEvent(string language)
        {
            this.language = language;
        }
    }
}
