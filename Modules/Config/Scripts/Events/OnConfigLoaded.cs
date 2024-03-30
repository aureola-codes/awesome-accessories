using Aureola.PubSub;

namespace Aureola.Config
{
    public class OnConfigLoaded : IPubSubEvent
    {
        public readonly ConfigManager manager;
        public OnConfigLoaded(ConfigManager configManager)
        {
            manager = configManager;
        }
    }
}
