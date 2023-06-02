using Aureola.PubSub;
using UnityEngine;

namespace Aureola.Audio
{
    [RequireComponent(typeof(AudioSource))]
    public class SyncSoundVolume : MonoBehaviour
    {
        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        private void OnEnable()
        {
            SyncVolume();
            PubSubManager.service?.Subscribe(Channel.AUDIO, typeof(VolumeChanged), OnVolumeChanged);
        }

        private void OnDisable()
        {
           PubSubManager.service?.Unsubscribe(Channel.AUDIO, typeof(VolumeChanged), OnVolumeChanged);
        }

        private void OnVolumeChanged(IGameEvent gameEvent)
        {
            SyncVolume();
        }

        private void SyncVolume()
        {
            _audioSource.volume = AudioManager.service?.soundVolumeAdjusted ?? 1f;
        }
    }
}
