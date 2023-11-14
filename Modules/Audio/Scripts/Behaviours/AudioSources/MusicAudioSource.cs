using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aureola.Audio
{
    [RequireComponent(typeof(AudioSource))]
    [RequireComponent(typeof(SyncMusicVolume))]
    public class MusicAudioSource : MonoBehaviour
    {
        [Header("Dependencies")]
        [SerializeField] private AudioObject _audio;

        private void OnEnable()
        {
            _audio.musicAudioSource = GetComponent<AudioSource>();
        }

        private void OnDisable()
        {
            _audio.musicAudioSource = null;
        }
    }
}
