using Aureola.PubSub;

namespace Aureola.Settings
{
    public class OnSettingsChanged : IPubSubEvent
    {
        public readonly SettingsManager manager;
        public OnSettingsChanged(SettingsManager settingsManager)
        {
            manager = settingsManager;
        }
    }
}
