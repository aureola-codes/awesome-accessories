using UnityEngine;

namespace Aureola.Audio
{
    [CreateAssetMenu(fileName = "AudioManager", menuName = "Aureola/Audio/AudioManager", order = 0)]
    public class AudioManager : ScriptableObject, IResettable, ILocatable
    {
        private AudioSource _musicAudioSource;
        private AudioSource _soundAudioSource;
        private AudioSource _voiceAudioSource;

        private float _masterVolume = 1f;
        private float _musicVolume = 0.5f;
        private float _soundVolume = 0.5f;
        private float _voiceVolume = 0.5f;

        public delegate void VolumeChanged();
        public VolumeChanged OnVolumeChanged;

        public AudioSource MusicAudioSource {
            set {
                if (_musicAudioSource != null && value != null) {
                    Debug.LogWarning("Music audio source already registered!");
                    return;
                }

                _musicAudioSource = value;
            }
        }

        public AudioSource SoundAudioSource {
            set {
                if (_soundAudioSource != null && value != null) {
                    Debug.LogWarning("Sound audio source already registered!");
                    return;
                }

                _soundAudioSource = value;
            }
        }

        public AudioSource VoiceAudioSource {
            set {
                if (_voiceAudioSource != null && value != null) {
                    Debug.LogWarning("Voice audio source already registered!");
                    return;
                }

                _voiceAudioSource = value;
            }
        }

        public bool IsMusicPlaying {
            get => _musicAudioSource?.isPlaying ?? false;
        }

        public bool IsSoundPlaying {
            get => _soundAudioSource?.isPlaying ?? false;
        }

        public bool IsVoicePlaying {
            get => _voiceAudioSource?.isPlaying ?? false;
        }

        public float MasterVolume {
            get => _masterVolume;
            set {
                if (_masterVolume != value) {
                    _masterVolume = value;
                    OnVolumeChanged?.Invoke();
                }
            }
        }

        public float MusicVolume {
            get => _musicVolume;
            set {
                if (_musicVolume != value) {
                    _musicVolume = value;
                    OnVolumeChanged?.Invoke();
                }
            }
        }

        public float SoundVolume {
            get => _soundVolume;
            set {
                if (_soundVolume != value) {
                    _soundVolume = value;
                    OnVolumeChanged?.Invoke();
                }
            }
        }

        public float VoiceVolume {
            get => _voiceVolume;
            set {
                if (_voiceVolume != value) {
                    _voiceVolume = value;
                    OnVolumeChanged?.Invoke();
                }
            }
        }

        public float MusicVolumeAdjusted {
            get => _musicVolume * _masterVolume;
        }

        public float SoundVolumeAdjusted {
            get => _soundVolume * _masterVolume;
        }

        public float VoiceVolumeAdjusted {
            get => _voiceVolume * _masterVolume;
        }

        public void PlayMusic(AudioClip music)
        {
            _musicAudioSource.clip = music;
            if (!_musicAudioSource.isPlaying) {
                _musicAudioSource.Play();
            }
        }

        public void StopMusic()
        {
            _musicAudioSource.Stop();
        }

        public void StopMusic(AudioClip music)
        {
            if (music == null || _musicAudioSource.clip == music) {
                StopMusic();
            }
        }

        public void PlaySound(AudioClip sound)
        {
            _soundAudioSource.PlayOneShot(sound);
        }

        public void StopSound()
        {
            _soundAudioSource.Stop();
        }

        public void PlayVoice(AudioClip voice)
        {
            _voiceAudioSource.PlayOneShot(voice);
        }

        public void StopVoice()
        {
            _voiceAudioSource.Stop();
        }

        public void Reset()
        {
            OnVolumeChanged = null;
        }
    }
}
