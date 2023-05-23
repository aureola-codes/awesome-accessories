using UnityEngine;

namespace Aureola.Audio
{
    public class AudioService : MonoBehaviour
    {
        private AudioSource _musicPlayer;
        private AudioSource _soundPlayer;
        private AudioSource _voicePlayer;

        private float _masterVolume = 1f;
        private float _musicVolume = 0.5f;
        private float _soundVolume = 0.5f;
        private float _voiceVolume = 0.5f;

        public delegate void OnUpdate();
        public OnUpdate onUpdate;

        public bool isMusicPlaying {
            get => _musicPlayer.isPlaying;
        }

        public bool isSoundPlaying {
            get => _soundPlayer.isPlaying;
        }

        public bool isVoicePlaying {
            get => _voicePlayer.isPlaying;
        }

        public float masterVolume {
            get => _masterVolume;
            set {
                _masterVolume = value;
                _musicPlayer.volume = musicVolume;
                _soundPlayer.volume = soundVolume;
                _voicePlayer.volume = voiceVolume;
                onUpdate?.Invoke();
            }
        }

        public float musicVolume {
            get => _musicVolume;
            set {
                _musicVolume = value;
                _musicPlayer.volume = musicVolumeAdjusted;
                onUpdate?.Invoke();
            }
        }

        public float soundVolume {
            get => _soundVolume;
            set {
                _soundVolume = value;
                _soundPlayer.volume = soundVolumeAdjusted;
                onUpdate?.Invoke();
            }
        }

        public float voiceVolume {
            get => _voiceVolume;
            set {
                _voiceVolume = value;
                _voicePlayer.volume = voiceVolumeAdjusted;
                onUpdate?.Invoke();
            }
        }

        public float musicVolumeAdjusted {
            get => _musicVolume * _masterVolume;
        }

        public float soundVolumeAdjusted {
            get => _soundVolume * _masterVolume;
        }

        public float voiceVolumeAdjusted {
            get => _voiceVolume * _masterVolume;
        }

        public AudioService(AudioSource musicPlayer, AudioSource soundPlayer, AudioSource voicePlayer)
        {
            _musicPlayer = musicPlayer;
            _soundPlayer = soundPlayer;
            _voicePlayer = voicePlayer;
        }

        public void PlayMusic(AudioClip music)
        {
            _musicPlayer.clip = music;
            if (!_musicPlayer.isPlaying) {
                _musicPlayer.Play();
            }
        }

        public void StopMusic()
        {
            _musicPlayer.Stop();
        }

        public void StopMusic(AudioClip music)
        {
            if (_musicPlayer.clip == music) {
                StopMusic();
            }
        }

        public void PlaySound(AudioClip sound, bool stop = false)
        {
            _soundPlayer.PlayOneShot(sound);
        }

        public void StopSound()
        {
            _soundPlayer.Stop();
        }

        public void PlayVoice(AudioClip voice, bool stop = false)
        {
            _voicePlayer.PlayOneShot(voice);
        }

        public void StopVoice()
        {
            _voicePlayer.Stop();
        }
    }
}
