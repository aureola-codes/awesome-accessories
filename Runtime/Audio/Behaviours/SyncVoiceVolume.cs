using UnityEngine;

namespace Aureola.Accessories
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
            PubSubManager.instance?.Subscribe(Channel.AUDIO, OnAudioEvent);
        }

        private void OnDisable()
        {
           PubSubManager.instance?.Unsubscribe(Channel.AUDIO, OnAudioEvent);
        }

        private void OnAudioEvent(IGameEvent gameEvent)
        {
            if (gameEvent.GetType() == typeof(AudioEvent)) {
                SyncVolume();
            }
        }

        private void SyncVolume()
        {
            _audioSource.volume = AudioManager.instance?.voiceVolumeAdjusted ?? 1f;
        }
    }
}
