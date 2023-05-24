using Aureola.PubSub;

namespace Aureola.Translation
{
    public class LanguageChanged : IGameEvent
    {
        public string language;
        public LanguageChanged(string language)
        {
            this.language = language;
        }
    }
}
