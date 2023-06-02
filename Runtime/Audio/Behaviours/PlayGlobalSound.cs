using System.Collections.Generic;
using UnityEngine;

namespace Aureola.Audio
{
    public class PlayGlobalSound : MonoBehaviour
    {
        [SerializeField] private bool _playOnEnable = false;
        [SerializeField] private List<AudioClip> _soundEffects;

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
            AudioManager.service?.PlaySound(GetAudioClip());
        }
    }
}
