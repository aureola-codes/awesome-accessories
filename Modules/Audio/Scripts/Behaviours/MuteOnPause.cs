using UnityEngine;

namespace Aureola.Audio
{
    [RequireComponent(typeof(AudioSource))]
    public class MuteOnPause : MonoBehaviour
    {
        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        private void Update()
        {
            _audioSource.mute = Time.timeScale == 0;
        }
    }
}
