using Aureola.PubSub;

namespace Aureola.Settings
{
    public class OnSettingsError : IPubSubEvent
    {
        public readonly SettingsManager manager;
        public readonly string errorMessage;
        public OnSettingsError(SettingsManager settingsManager, string error)
        {
            manager = settingsManager;
            errorMessage = error;
        }
    }
}
