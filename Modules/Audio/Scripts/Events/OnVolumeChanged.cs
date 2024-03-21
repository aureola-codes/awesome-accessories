using Aureola.PubSub;

namespace Aureola.Audio
{
    public class OnVolumeChanged : IEvent
    {
        public readonly AudioManager Manager;
        public OnVolumeChanged(AudioManager manager)
        {
            Manager = manager;
        }
    }
}
