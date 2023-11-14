using UnityEngine;

namespace Aureola.Audio
{
    public class PlayMusic : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private bool _playOnEnable = false;
        [SerializeField] private AudioClip _music;

        [Header("Dependencies")]
        [SerializeField] private AudioObject _audio;

        private void OnEnable()
        {
            if (_playOnEnable) {
                Play();
            }
        }


        [ContextMenu("Play Music")]
        public void Play()
        {
            _audio.PlayMusic(_music);
        }

        [ContextMenu("Stop Music")]
        public void Stop()
        {
            _audio.StopMusic(_music);
        }
    }
}
