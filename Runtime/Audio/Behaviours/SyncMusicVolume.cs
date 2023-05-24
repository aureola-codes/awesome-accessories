using Aureola.PubSub;
using UnityEngine;

namespace Aureola.Audio
{
    [RequireComponent(typeof(AudioSource))]
    public class SyncMusicVolume : MonoBehaviour
    {
        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        private void OnEnable()
        {
            SyncVolume();
            PubSubManager.instance?.Subscribe(Channel.AUDIO, OnVolumeChanged);
        }

        private void OnDisable()
        {
           PubSubManager.instance?.Unsubscribe(Channel.AUDIO, OnVolumeChanged);
        }

        private void OnVolumeChanged(IGameEvent gameEvent)
        {
            if (gameEvent.GetType() == typeof(VolumeChanged)) {
                SyncVolume();
            }
        }

        private void SyncVolume()
        {
            _audioSource.volume = AudioManager.instance?.musicVolumeAdjusted ?? 1f;
        }
    }
}
