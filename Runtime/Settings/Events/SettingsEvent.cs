using Aureola.PubSub;

namespace Aureola.Settings
{
    public class SettingsEvent : IGameEvent
    {
        public ISettingsData settings;
        public SettingsEvent(ISettingsData settings)
        {
            this.settings = settings;
        }
    }
}
