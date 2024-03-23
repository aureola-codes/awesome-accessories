using Aureola.PubSub;

namespace Aureola.Settings
{
    public class OnSettingsLoaded : IPubSubEvent
    {
        public readonly SettingsManager Manager;
        public OnSettingsLoaded(SettingsManager manager)
        {
            Manager = manager;
        }
    }
}

