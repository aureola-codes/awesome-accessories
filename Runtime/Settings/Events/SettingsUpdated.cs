using Aureola.PubSub;

namespace Aureola.Settings
{
    public class SettingsUpdated : IGameEvent
    {
        public ISettingsData settings;
        public SettingsUpdated(ISettingsData settings)
        {
            this.settings = settings;
        }
    }
}
