using Aureola.PubSub;
using Aureola.Settings;
using UnityEngine;

namespace Aureola.Audio
{
    public class AudioManager : MonoBehaviour
    {
        private static AudioService _service;
        private bool _isDirty = false;

        [Header("Settings")]
        [SerializeField] private AudioSource _musicPlayer;
        [SerializeField] private AudioSource _soundPlayer;
        [SerializeField] private AudioSource _voicePlayer;

        public static AudioService service
        {
            get => _service;
        }

        private void Awake()
        {
            _service = new AudioService(_musicPlayer, _soundPlayer, _voicePlayer);
            _service.onVolumeChanged += () => _isDirty = true;
        }

        private void OnEnable()
        {
            PubSubManager.service?.Subscribe(Channel.SETTINGS, typeof(SettingsUpdated), OnSettingsUpdated);
        }

        private void OnDisable()
        {
            PubSubManager.service?.Unsubscribe(Channel.SETTINGS, typeof(SettingsUpdated), OnSettingsUpdated);
        }

        private void LateUpdate()
        {
            if (_isDirty) {
                _isDirty = false;
                PubSubManager.service?.Send(Channel.AUDIO, new VolumeChanged());
            }
        }

        private void OnSettingsUpdated(IGameEvent data)
        {
            var eventData = (SettingsUpdated) data;
            var settingsData = (SettingsData) eventData.settings;

            _service.masterVolume = settingsData.masterVolume;
            _service.musicVolume = settingsData.musicVolume;
            _service.soundVolume = settingsData.soundVolume;
            _service.voiceVolume = settingsData.voiceVolume;
        }
    }
}
