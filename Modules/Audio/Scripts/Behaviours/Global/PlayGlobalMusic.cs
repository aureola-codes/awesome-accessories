using UnityEngine;

namespace Aureola.Audio
{
    public class PlayMusic : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private bool _playOnEnable = false;
        [SerializeField] private AudioClip _music;

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
            if (_playOnEnable) {
                Play();
            }
        }


        [ContextMenu("Play Music")]
        public void Play()
        {
            _audioManager.PlayMusic(_music);
        }

        [ContextMenu("Stop Music")]
        public void Stop()
        {
            _audioManager.StopMusic(_music);
        }
    }
}
