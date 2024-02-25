using UnityEngine;

namespace Aureola.Audio
{
    [RequireComponent(typeof(AudioSource))]
    [RequireComponent(typeof(MusicVolumeSync))]
    public class MusicAudioSource : MonoBehaviour
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
            _audioManager.MusicAudioSource = GetComponent<AudioSource>();
        }

        private void OnDisable()
        {
            _audioManager.MusicAudioSource = null;
        }
    }
}
