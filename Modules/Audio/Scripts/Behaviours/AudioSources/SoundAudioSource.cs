using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aureola.Audio
{
    [RequireComponent(typeof(AudioSource))]
    [RequireComponent(typeof(SyncSoundVolume))]
    public class SoundAudioSource : MonoBehaviour
    {
        [Header("Dependencies")]
        [SerializeField] private AudioManager _audio;

        private void OnEnable()
        {
            _audio.soundAudioSource = GetComponent<AudioSource>();
        }

        private void OnDisable()
        {
            _audio.soundAudioSource = null;
        }
    }
}

