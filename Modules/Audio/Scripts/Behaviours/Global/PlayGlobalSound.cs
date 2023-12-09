using System.Collections.Generic;
using UnityEngine;

namespace Aureola.Audio
{
    public class PlayGlobalSound : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private bool _playOnEnable = false;
        [SerializeField] private List<AudioClip> _soundEffects;

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
        
        private AudioClip GetAudioClip()
        {
            if (_soundEffects.Count == 1) {
                return _soundEffects[0];
            }

            return _soundEffects[Random.Range(0, _soundEffects.Count)];
        }

        [ContextMenu("Play Sound")]
        public void Play()
        {
            _audioManager.PlaySound(GetAudioClip());
        }
    }
}
