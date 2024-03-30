namespace Aureola.Audio
{
    public class MusicVolumeSync : BaseVolumeSync
    {
        override protected void SyncVolume()
        {
            _audioSource.volume = _audioManager.musicVolumeAdjusted;
        }
    }
}
