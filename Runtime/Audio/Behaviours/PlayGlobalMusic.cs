using UnityEngine;

namespace Aureola.Accessories
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
            AudioManager.instance?.PlayMusic(_music);
        }

        [ContextMenu("Stop Music")]
        public void Stop()
        {
            AudioManager.instance?.StopMusic(_music);
        }
    }
}
