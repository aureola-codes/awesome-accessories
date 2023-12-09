using UnityEngine;

namespace Aureola.Audio
{
    [RequireComponent(typeof(AudioSource))]
    public class SyncSoundVolume : MonoBehaviour
    {
        private AudioSource _audioSource;

        [Header("Dependencies")]
        [SerializeField] private AudioManager _audioManager;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            if (_audioManager == null) {
                _audioManager = SOLocator.Get<AudioManager>();
            }
        }

        private void OnEnable()
        {
            SyncVolume();
            _audioManager.onVolumeChanged += SyncVolume;
        }

        private void OnDisable()
        {
            _audioManager.onVolumeChanged -= SyncVolume;
        }

        private void SyncVolume()
        {
            _audioSource.volume = _audioManager.soundVolumeAdjusted;
        }
    }
}
