namespace Aureola.Audio
{
    public class SoundVolumeSlider : BaseVolumeSlider
    {
        private void Start()
        {
            _slider.value = _audioManager.SoundVolume;
        }

        override protected void OnValueChanged(float value)
        {
            _audioManager.SoundVolume = value;
        }
    }
}
