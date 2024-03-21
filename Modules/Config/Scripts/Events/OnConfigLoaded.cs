using Aureola.PubSub;

namespace Aureola.Config
{
    public class OnConfigLoaded : IEvent
    {
        public readonly ConfigManager Manager;
        public OnConfigLoaded(ConfigManager manager)
        {
            Manager = manager;
        }
    }
}
