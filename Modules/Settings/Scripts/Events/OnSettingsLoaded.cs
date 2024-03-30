using Aureola.PubSub;

namespace Aureola.Settings
{
    public class OnSettingsLoaded : IPubSubEvent
    {
        public readonly SettingsManager manager;
        public OnSettingsLoaded(SettingsManager settingsManager)
        {
            manager = settingsManager;
        }
    }
}

