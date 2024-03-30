namespace Aureola.Audio
{
    public class SoundVolumeSync : BaseVolumeSync
    {
        override protected void SyncVolume()
        {
            _audioSource.volume = _audioManager.soundVolumeAdjusted;
        }
    }
}
