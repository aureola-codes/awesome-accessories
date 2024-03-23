using Aureola.PubSub;

namespace Aureola.Settings
{
    public class OnSettingsChanged : IPubSubEvent
    {
        public readonly SettingsManager Manager;
        public OnSettingsChanged(SettingsManager manager)
        {
            Manager = manager;
        }
    }
}
