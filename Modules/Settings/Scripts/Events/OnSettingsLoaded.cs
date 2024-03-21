using Aureola.PubSub;

namespace Aureola.Settings
{
    public class OnSettingsLoaded : IEvent
    {
        public readonly SettingsManager Manager;
        public OnSettingsLoaded(SettingsManager manager)
        {
            Manager = manager;
        }
    }
}

