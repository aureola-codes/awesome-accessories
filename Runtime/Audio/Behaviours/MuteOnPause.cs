using UnityEngine;

namespace Aureola.Accessories
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
            _audioSource.mute = TimeScaleManager.instance?.IsPaused() ?? false;
        }
    }
}
