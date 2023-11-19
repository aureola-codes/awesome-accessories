using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aureola.Audio
{
    [RequireComponent(typeof(AudioSource))]
    [RequireComponent(typeof(SyncVoiceVolume))]
    public class VoiceAudioSource : MonoBehaviour
    {
        [Header("Dependencies")]
        [SerializeField] private AudioManager _audio;

        private void OnEnable()
        {
            _audio.voiceAudioSource = GetComponent<AudioSource>();
        }

        private void OnDisable()
        {
            _audio.voiceAudioSource = null;
        }
    }
}

