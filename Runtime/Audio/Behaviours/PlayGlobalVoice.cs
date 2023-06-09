using System.Collections.Generic;
using UnityEngine;

namespace Aureola.Audio
{
    public class PlayGlobalVoice : MonoBehaviour
    {
        [SerializeField] private bool _playOnEnable = false;
        [SerializeField] private List<AudioClip> _voiceOvers;

        private void OnEnable()
        {
            if (_playOnEnable) {
                Play();
            }
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
            AudioManager.service?.PlayVoice(GetAudioClip());
        }
    }
}
