using UnityEngine;

namespace Aureola.Audio
{
    [RequireComponent(typeof(AudioSource))]
    public class SyncSoundVolume : MonoBehaviour
    {
        private AudioSource _audioSource;

        [Header("Dependencies")]
        [SerializeField] private AudioManager _audio;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        private void OnEnable()
        {
            SyncVolume();
            _audio.onVolumeChanged += SyncVolume;
        }

        private void OnDisable()
        {
            _audio.onVolumeChanged -= SyncVolume;
        }

        private void SyncVolume()
        {
            _audioSource.volume = _audio.soundVolumeAdjusted;
        }
    }
}
