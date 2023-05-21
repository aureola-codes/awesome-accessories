using System.Collections.Generic;
using UnityEngine;

namespace Aureola.Accessories
{
    [RequireComponent(typeof(AudioSource))]
    [RequireComponent(typeof(SyncVoiceVolume))]
    public class PlayVoice : MonoBehaviour
    {
        private AudioSource _audioSource;
        [SerializeField] private bool _playOnEnable = false;
        [SerializeField] private List<AudioClip> _soundEffects;

        private void OnEnable()
        {
            if (_playOnEnable) {
                Play();
            }
        }

        private void OnDisable()
        {
            Stop();
        }

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        private AudioClip GetAudioClip()
        {
            if (_soundEffects.Count == 1) {
                return _soundEffects[0];
            }

            return _soundEffects[Random.Range(0, _soundEffects.Count)];
        }

        [ContextMenu("Play Voice")]
        public void Play()
        {
            _audioSource.PlayOneShot(GetAudioClip());
        }

        [ContextMenu("Stop Voice")]
        public void Stop()
        {
            _audioSource.Stop();
        }
    }
}
