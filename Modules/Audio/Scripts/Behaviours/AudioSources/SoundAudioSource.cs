using UnityEngine;

namespace Aureola.Audio
{
    [RequireComponent(typeof(AudioSource))]
    [RequireComponent(typeof(SoundVolumeSync))]
    public class SoundAudioSource : MonoBehaviour
    {
        [Header("Dependencies")]
        [SerializeField] private AudioManager _audioManager;

        private void Awake()
        {
            if (_audioManager == null) {
                _audioManager = SOLocator.Get<AudioManager>();
            }
        }

        private void OnEnable()
        {
            _audioManager.soundAudioSource = GetComponent<AudioSource>();
        }

        private void OnDisable()
        {
            _audioManager.soundAudioSource = null;
        }
    }
}

