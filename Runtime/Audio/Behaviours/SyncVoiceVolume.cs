using Aureola.PubSub;
using UnityEngine;

namespace Aureola.Audio
{
    [RequireComponent(typeof(AudioSource))]
    public class SyncVoiceVolume : MonoBehaviour
    {
        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        private void OnEnable()
        {
            SyncVolume();
            PubSubManager.instance?.Subscribe(Channel.AUDIO, typeof(AudioEvent), OnAudioEvent);
        }

        private void OnDisable()
        {
           PubSubManager.instance?.Unsubscribe(Channel.AUDIO, typeof(AudioEvent), OnAudioEvent);
        }

        private void OnAudioEvent(IGameEvent gameEvent)
        {
            SyncVolume();
        }

        private void SyncVolume()
        {
            _audioSource.volume = AudioManager.instance?.voiceVolumeAdjusted ?? 1f;
        }
    }
}
