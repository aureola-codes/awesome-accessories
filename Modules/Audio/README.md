# Audio

The **AudioManager** is responsible for playing global sound effects, voice overs and music. It also manages the volume of the respective *AudioSources* and thereby powers several audio related behaviours. 

## AudioService

Create a new audio service:

```
var audioService = new AudioService(musicPlayer, soundPlayer, voicePlayer);
```

Find out if music, sounds or voices are playing:

```
if (audioService.isMusicPlaying) {
  // Do stuff...
}
if (audioService.isAudioPlaying) {
  // Do stuff...
}
if (audioService.isVoicePlaying) {
  // Do stuff...
}
```

Set the master, music, sound or voice player's volume:

```
audioService.masterVolume = 1f;
audioService.musicVolume = 0.5f;
audioService.soundVolume = 0.8f;
audioService.voiceVolume = 0.2f;
```

Use the service's volumes to update volumes of *AudioSources*:

```
myAudioSource.volume = audioService.musicVolume * audioSource.masterVolume;
myAudioSource.volume = audioService.soundVolume * audioSource.masterVolume;
myAudioSource.volume = audioService.voiceVolume * audioSource.masterVolume;
```

Play & stop sound effects, music and voice overs:

```
audioService.PlayMusic(myMusicClip);
audioService.StopMusic();

audioService.PlaySound(mySoundClip);
audioService.StopSound();

audioService.PlayVoice(myVoiceClip);
audioService.StopVoice();
```

Listen to volume changes:

```
audioService.onVolumeChanged += () => {
  // Do something...
}
```

## AudioManager

### Settings

- **musicPlayer** AudioSource for the music.
- **soundPlayer** AudioSource for global sound effects.
- **voicePlayer** AudioSource for global voice overs.

### Events

- Events are published in the channel **Audio**.
- **VolumeChanged** Triggered when any volume variable of the **AudioService** is changed.

## Behaviours

### MuteOnPause

Uses the **TimeScaleManager** to check, if the game is paused. Mutes any *AudioSource* this behaviour is attached to, while the game is paused. Can be handy to mute game sounds or music, when the player has paused the game.

### PlayGlobalMusic

Plays an *AudioClip* on the music *AudioSource* of the **AudioManager**. Either plays the music once enabled or when you call the **Play()** method. Please note: Does not stop the music, when GameObject is destroyed or disabled.

**Settings:**

- **playOnEnable** Play audio clip as soon as the GameObject is enabled.
- **music** The *AudioClip* to play.

### PlayGlobalSound

Plays a random *AudioClip* on the sound *AudioSource* of the **AudioManager**. Either plays the sound once enabled or when you call the **Play()** method. Can be handy to play one-off sounds, when a GameObject is created. E.g. a notification message.

**Settings:**

- **playOnEnable** Play audio clip as soon as the GameObject is enabled.
- **soundEffects** A list of *AudioClips* to play. The respective *AudioClip* will be randomly selected.

### PlayGlobalVoice

Plays a random *AudioClip* on the voice *AudioSource* of the **AudioManager**. Either plays the voice over once enabled or when you call the **Play()** method. Can be handy to play one-off voice overs, when a GameObject is created. E.g. voice over of a unit in an RTS when spawned.

**Settings:**

- **playOnEnable** Play audio clip as soon as the GameObject is enabled.
- **voiceOvers** A list of *AudioClips* to play. The respective *AudioClip* will be randomly selected.

### PlaySound

Plays a random *AudioClip* on the respective GameObject's *AudioSource*. Either plays the sound once enabled or when you call the **Play()** method. Can be handy to play one-off sounds, when a GameObject is created. E.g. an explosion.

**Settings:**

- **playOnEnable** Play audio clip as soon as the GameObject is enabled.
- **soundEffects** A list of *AudioClips* to play. The respective *AudioClip* will be randomly selected.

### PlayVoice

Plays a random *AudioClip* on the respective GameObject's *AudioSource*. Either plays the voice over once enabled or when you call the **Play()** method. Can be handy to play one-off voice overs, when a GameObject is created. E.g. an NPC coughing in the background.

**Settings:**

- **playOnEnable** Play audio clip as soon as the GameObject is enabled.
- **voiceOvers** A list of *AudioClips* to play. The respective *AudioClip* will be randomly selected.

### SyncMusicVolume

Syncs the volume of this GameObject's *AudioSource* with the current music volume of the **AudioManager**.

### SyncSoundVolume

Syncs the volume of this GameObject's *AudioSource* with the current sound volume of the **AudioManager**.

### SyncVoiceVolume

Syncs the volume of this GameObject's *AudioSource* with the current voice volume of the **AudioManager**.
