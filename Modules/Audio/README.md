# Audio

The audio module contains everything related to audio playback.

## AudioManager

The AudioManager class is designed to manage audio sources and volumes within a Unity project. It allows for the control of music, sound effects, and voice separately with individual volume controls as well as a master volume control that affects all audio sources. The class includes functionality to play, stop, and check if audio is playing. It also provides adjusted volume properties that take into account both individual and master volumes.

### Properties

- `musicAudioSource` Set the AudioSource for music.
- `soundAudioSource` Set the AudioSource for sound effects.
- `voiceAudioSource` Set the AudioSource for voice.
- `isMusicPlaying` Returns true if music is currently playing.
- `isSoundPlaying` Returns true if a sound effect is currently playing.
- `isVoicePlaying` Returns true if voice audio is currently playing.
- `masterVolume` Get or set the master volume for all audio sources.
- `musicVolume` Get or set the volume for music.
- `soundVolume` Get or set the volume for sound effects.
- `voiceVolume` Get or set the volume for voice.
- `musicVolumeAdjusted` Get the adjusted music volume considering the master volume.
- `soundVolumeAdjusted` Get the adjusted sound volume considering the master volume.
- `voiceVolumeAdjusted` Get the adjusted voice volume considering the master volume.

### Methods

- `PlayMusic(AudioClip music)` Play a music AudioClip.
- `StopMusic()` Stop playing the current music.
- `StopMusic(AudioClip music)` Stop playing the specified music AudioClip.
- `PlaySound(AudioClip sound)` Play a sound effect AudioClip.
- `StopSound()` Stop playing the current sound effect.
- `PlayVoice(AudioClip voice)` Play a voice AudioClip.
- `StopVoice()` Stop playing the current voice audio.
- `Reset()` Resets the AudioManager.

### Delegates

- `OnVolumeChanged` An event that triggers when the volume is changed.

### Events (PubSubManager)

- `OnVolumeChanged` An event that triggers when the volume is changed.

### Example Usages

**Setting Audio Sources**

```csharp
public AudioSource musicSource;
public AudioSource soundSource;
public AudioSource voiceSource;

public AudioManager audioManager; // Assume this is already assigned through the inspector or elsewhere

void Start() {
    audioManager.musicAudioSource = musicSource;
    audioManager.soundAudioSource = soundSource;
    audioManager.voiceAudioSource = voiceSource;
}
```

**Playing Audio**

```csharp
public AudioClip musicClip;
public AudioClip soundClip;
public AudioClip voiceClip;

void PlayAudio() {
    audioManager.PlayMusic(musicClip);
    audioManager.PlaySound(soundClip);
    audioManager.PlayVoice(voiceClip);
}
```

**Adjusting Volumes**

```csharp
void AdjustVolumes() {
    audioManager.masterVolume = 0.8f;
    audioManager.musicVolume = 0.5f;
    audioManager.soundVolume = 0.7f;
    audioManager.voiceVolume = 0.9f;
}
```

**Stopping Audio**

```csharp
void StopAllAudio() {
    audioManager.StopMusic();
    audioManager.StopSound();
    audioManager.StopVoice();
}
```

**Resetting Volume Change Event**

```csharp
void ResetVolumeChangeEvent() {
    audioManager.Reset();
}
```

## Behaviours

**Register Audio Sources**

- `MusicAudioSource` Registers itself as the music audio source.
- `SoundAudioSource` Registers itself as the sound audio source.
- `VoiceAudioSource` Registers itself as the voice audio source.

**Play Global Audio**

- `PlayGlobalMusic` Plays a music audio clip globally.
- `PlayGlobalSound` Plays a sound audio clip globally.
- `PlayGlobalVoice` Plays a voice audio clip globally.

**Play Local Audio**

- `PlaySound` Plays a sound audio clip on the local audio source.
- `PlayVoice` Plays a voice audio clip on the local audio source.

**Sync Audio Volume**

- `MusicVolumeSync` Syncs audio source's volume with the music volume set in the audio manager.
- `SoundVolumeSync` Syncs audio source's volume with the sound volume set in the audio manager.
- `VoiceVolumeSync` Syncs audio source's volume with the voice volume set in the audio manager.

**Set Audio Volume**

- `MasterVolumeSlider` Sets the master volume using a slider.
- `MusicVolumeSlider` Sets the music volume using a slider.
- `SoundVolumeSlider` Sets the sound volume using a slider.
- `VoiceVolumeSlider` Sets the voice volume using a slider.

**Miscellaneous**

- `MuteOnPause` Mutes the local audio source when the game is paused.

---

**Example:** [/Examples/AudioManager](/Examples/AudioManager)
