namespace Aureola.Audio
{
    public class MasterVolumeSlider : BaseVolumeSlider
    {
        private void Start()
        {
            _slider.value = _audioManager.masterVolume;
        }

        override protected void OnValueChanged(float value)
        {
            _audioManager.masterVolume = value;
        }
    }
}
