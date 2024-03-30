namespace Aureola.Audio
{
    public class VoiceVolumeSlider : BaseVolumeSlider
    {
        private void Start()
        {
            _slider.value = _audioManager.voiceVolume;
        }

        override protected void OnValueChanged(float value)
        {
            _audioManager.voiceVolume = value;
        }
    }
}
