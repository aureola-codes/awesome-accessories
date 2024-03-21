using Aureola.PubSub;

namespace Aureola.Settings
{
    public class OnSettingsStored : IEvent
    {
        public readonly SettingsManager Manager;
        public OnSettingsStored(SettingsManager manager)
        {
            Manager = manager;
        }
    }
}

