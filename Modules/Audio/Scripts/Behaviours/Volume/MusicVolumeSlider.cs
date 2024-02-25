namespace Aureola.Audio
{
    public class MusicVolumeSlider : BaseVolumeSlider
    {
        private void Start()
        {
            _slider.value = _audioManager.MusicVolume;
        }

        override protected void OnValueChanged(float value)
        {
            _audioManager.MusicVolume = value;
        }
    }
}
