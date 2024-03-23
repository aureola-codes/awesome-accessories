using Aureola.PubSub;

namespace Aureola.Audio
{
    public class OnVolumeChanged : IPubSubEvent
    {
        public readonly AudioManager Manager;
        public OnVolumeChanged(AudioManager manager)
        {
            Manager = manager;
        }
    }
}
