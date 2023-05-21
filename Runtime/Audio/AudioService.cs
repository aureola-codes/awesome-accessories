using UnityEngine;

namespace Aureola.Accessories
{
    public class AudioService : MonoBehaviour
    {
        protected bool _isDirty = false;

        protected float _masterVolume = 1f;
        protected float _musicVolume = 0.5f;
        protected float _soundVolume = 0.5f;
        protected float _voiceVolume = 0.5f;

        [Header("Audio Sources")]
        [SerializeField] protected AudioSource _musicPlayer;
        [SerializeField] protected AudioSource _soundPlayer;
        [SerializeField] protected AudioSource _voicePlayer;

        public bool isMusicPlaying {
            get => _musicPlayer.isPlaying;
        }

        public bool isSoundPlaying {
            get => _soundPlayer.isPlaying;
        }

        public bool isVoicePlaying {
            get => _voicePlayer.isPlaying;
        }
        
        protected void OnEnable()
        {
            PubSubManager.instance?.Subscribe(Channel.SETTINGS, OnSettingsUpdated);
        }

        protected void OnDisable()
        {
            PubSubManager.instance?.Unsubscribe(Channel.SETTINGS, OnSettingsUpdated);
        }

        protected void LateUpdate()
        {
            if (_isDirty) {
                _isDirty = false;
                PubSubManager.instance?.Send(Channel.AUDIO, new AudioEvent());
            }
        }

        protected void OnSettingsUpdated(IGameEvent data)
        {
            if (data.GetType() == typeof(SettingsEvent)) {
                var eventData = (SettingsEvent) data;
                var settingsData = (SettingsData) eventData.settings;

                SetMasterVolume(settingsData.masterVolume);
                SetMusicVolume(settingsData.musicVolume);
                SetSoundVolume(settingsData.soundVolume);
                SetVoiceVolume(settingsData.voiceVolume);
            }
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

        public void SetMasterVolume(float newVolume)
        {
            _masterVolume = newVolume;
            SetMusicVolume(_musicVolume);
            SetSoundVolume(_soundVolume);
            SetVoiceVolume(_voiceVolume);
        }

        public void SetMusicVolume(float newVolume)
        {
            _musicVolume = newVolume;
            _musicPlayer.volume = GetMusicVolume();
            _isDirty = true;
        }

        public float GetMusicVolume()
        {
            return _musicVolume * _masterVolume;
        }

        public void SetSoundVolume(float newVolume)
        {
            _soundVolume = newVolume;
            _soundPlayer.volume = GetSoundVolume();
            _isDirty = true;
        }

        public float GetSoundVolume()
        {
            return _soundVolume * _masterVolume;
        }

        public void SetVoiceVolume(float newVolume)
        {
            _voiceVolume = newVolume;
            _voicePlayer.volume = GetVoiceVolume();
            _isDirty = true;
        }

        public float GetVoiceVolume()
        {
            return _voiceVolume * _masterVolume;
        }
    }
}
