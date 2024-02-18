namespace Aureola.Audio
{
    public class MusicVolumeSlider : BaseVolumeSlider
    {
        private void Start()
        {
            _slider.value = _audioManager.musicVolume;
        }

        override protected void OnValueChanged(float value)
        {
            _audioManager.musicVolume = value;
        }
    }
}
