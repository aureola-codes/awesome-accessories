using Aureola.PubSub;

namespace Aureola.Settings
{
    public class OnSettingsError : IEvent
    {
        public readonly SettingsManager Manager;
        public readonly string ErrorMessage;
        public OnSettingsError(SettingsManager manager, string errorMessage)
        {
            Manager = manager;
            ErrorMessage = errorMessage;
        }
    }
}
