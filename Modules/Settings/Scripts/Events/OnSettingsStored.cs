using Aureola.PubSub;

namespace Aureola.Settings
{
    public class OnSettingsStored : IPubSubEvent
    {
        public readonly SettingsManager manager;
        public OnSettingsStored(SettingsManager settingsManager)
        {
            manager = settingsManager;
        }
    }
}

