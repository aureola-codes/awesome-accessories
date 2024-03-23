using Aureola.PubSub;

namespace Aureola.Config
{
    public class OnConfigLoaded : IPubSubEvent
    {
        public readonly ConfigManager Manager;
        public OnConfigLoaded(ConfigManager manager)
        {
            Manager = manager;
        }
    }
}
