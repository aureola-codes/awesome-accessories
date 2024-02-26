using System.Collections.Generic;
using UnityEngine;

namespace Aureola.Audio
{
    [RequireComponent(typeof(AudioSource))]
    [RequireComponent(typeof(SoundVolumeSync))]
    public class PlaySound : MonoBehaviour
    {
        private AudioSource _audioSource;

        [Header("Settings")]
        [SerializeField] private bool _playOnEnable = false;
        [SerializeField] private List<AudioClip> _soundEffects;

        private void OnEnable()
        {
            if (_playOnEnable) {
                Play();
            }
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

        [ContextMenu("Play Sound")]
        public void Play()
        {
            _audioSource.PlayOneShot(GetAudioClip());
        }
    }
}
