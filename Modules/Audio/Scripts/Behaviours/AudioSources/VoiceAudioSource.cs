using UnityEngine;

namespace Aureola.Audio
{
    [RequireComponent(typeof(AudioSource))]
    [RequireComponent(typeof(VoiceVolumeSync))]
    public class VoiceAudioSource : MonoBehaviour
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
            _audioManager.voiceAudioSource = GetComponent<AudioSource>();
        }

        private void OnDisable()
        {
            _audioManager.voiceAudioSource = null;
        }
    }
}

