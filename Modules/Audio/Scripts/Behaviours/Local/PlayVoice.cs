using System.Collections.Generic;
using UnityEngine;

namespace Aureola.Audio
{
    [RequireComponent(typeof(AudioSource))]
    [RequireComponent(typeof(SyncVoiceVolume))]
    public class PlayVoice : MonoBehaviour
    {
        private AudioSource _audioSource;

        [Header("Settings")]
        [SerializeField] private bool _playOnEnable = false;
        [SerializeField] private List<AudioClip> _voiceOvers;

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
            if (_voiceOvers.Count == 1) {
                return _voiceOvers[0];
            }

            return _voiceOvers[Random.Range(0, _voiceOvers.Count)];
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
