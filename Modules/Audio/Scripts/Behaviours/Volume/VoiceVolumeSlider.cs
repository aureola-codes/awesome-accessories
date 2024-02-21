namespace Aureola.Audio
{
    public class VoiceVolumeSlider : BaseVolumeSlider
    {
        private void Start()
        {
            _slider.value = _audioManager.VoiceVolume;
        }

        override protected void OnValueChanged(float value)
        {
            _audioManager.VoiceVolume = value;
        }
    }
}
