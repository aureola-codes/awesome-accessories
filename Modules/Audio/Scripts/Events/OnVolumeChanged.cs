using Aureola.PubSub;

namespace Aureola.Audio
{
    public class OnVolumeChanged : IPubSubEvent
    {
        public readonly AudioManager manager;
        public OnVolumeChanged(AudioManager audioManager)
        {
            manager = audioManager;
        }
    }
}
