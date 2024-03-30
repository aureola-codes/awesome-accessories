namespace Aureola.Audio
{
    public class SoundVolumeSlider : BaseVolumeSlider
    {
        private void Start()
        {
            _slider.value = _audioManager.soundVolume;
        }

        override protected void OnValueChanged(float value)
        {
            _audioManager.soundVolume = value;
        }
    }
}
