using UnityEngine;

namespace Aureola.Audio
{
    public class PlayMusic : MonoBehaviour
    {
        [SerializeField] private bool _playOnEnable = false;
        [SerializeField] private AudioClip _music;

        private void OnEnable()
        {
            if (_playOnEnable) {
                Play();
            }
        }


        [ContextMenu("Play Music")]
        public void Play()
        {
            AudioManager.service?.PlayMusic(_music);
        }

        [ContextMenu("Stop Music")]
        public void Stop()
        {
            AudioManager.service?.StopMusic(_music);
        }
    }
}
