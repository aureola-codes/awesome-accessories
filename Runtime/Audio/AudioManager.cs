using Aureola.PubSub;
using Aureola.Settings;
using UnityEngine;

namespace Aureola.Audio
{
    public class AudioManager : MonoBehaviour
    {
        private static AudioService _instance;
        private bool _isDirty = false;

        [Header("Settings")]
        [SerializeField] private AudioSource _musicPlayer;
        [SerializeField] private AudioSource _soundPlayer;
        [SerializeField] private AudioSource _voicePlayer;

        public static AudioService instance
        {
            get => _instance;
        }

        private void Awake()
        {
            _instance = new AudioService(_musicPlayer, _soundPlayer, _voicePlayer);
            _instance.onUpdate += () => _isDirty = true;
        }

        private void OnEnable()
        {
            PubSubManager.instance?.Subscribe(Channel.SETTINGS, typeof(SettingsUpdated), OnSettingsUpdated);
        }

        private void OnDisable()
        {
            PubSubManager.instance?.Unsubscribe(Channel.SETTINGS, typeof(SettingsUpdated), OnSettingsUpdated);
        }

        private void LateUpdate()
        {
            if (_isDirty) {
                _isDirty = false;
                PubSubManager.instance?.Send(Channel.AUDIO, new VolumeChanged());
            }
        }

        private void OnSettingsUpdated(IGameEvent data)
        {
            var eventData = (SettingsUpdated) data;
            var settingsData = (SettingsData) eventData.settings;

            _instance.masterVolume = settingsData.masterVolume;
            _instance.musicVolume = settingsData.musicVolume;
            _instance.soundVolume = settingsData.soundVolume;
            _instance.voiceVolume = settingsData.voiceVolume;
        }
    }
}
