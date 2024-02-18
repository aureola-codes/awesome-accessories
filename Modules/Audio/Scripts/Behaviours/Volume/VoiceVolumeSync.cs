namespace Aureola.Audio
{
    public class VoiceVolumeSync : BaseVolumeSync
    {
        override protected void SyncVolume()
        {
            _audioSource.volume = _audioManager.voiceVolumeAdjusted;
        }
    }
}
