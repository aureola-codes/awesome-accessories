using Aureola.PubSub;

namespace Aureola.Settings
{
    public class OnSettingsChanged : IEvent
    {
        public readonly SettingsManager Manager;
        public OnSettingsChanged(SettingsManager manager)
        {
            Manager = manager;
        }
    }
}
