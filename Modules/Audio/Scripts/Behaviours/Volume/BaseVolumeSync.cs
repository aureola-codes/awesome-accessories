using UnityEngine;

namespace Aureola.Audio
{
    [RequireComponent(typeof(AudioSource))]
    abstract public class BaseVolumeSync : MonoBehaviour
    {
        protected AudioSource _audioSource;

        [Header("Dependencies")]
        [SerializeField] protected AudioManager _audioManager;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            if (_audioManager == null) {
                _audioManager = SOLocator.Get<AudioManager>();
            }
        }

        private void OnEnable()
        {
            _audioManager.onVolumeChanged += SyncVolume;
            SyncVolume();
        }

        private void OnDisable()
        {
           _audioManager.onVolumeChanged -= SyncVolume;
        }

        protected abstract void SyncVolume();
    }
}
