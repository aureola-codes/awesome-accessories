using Aureola.PubSub;

namespace Aureola.Settings
{
    public class OnSettingsStored : IPubSubEvent
    {
        public readonly SettingsManager Manager;
        public OnSettingsStored(SettingsManager manager)
        {
            Manager = manager;
        }
    }
}

