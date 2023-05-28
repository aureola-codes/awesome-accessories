# Video

This module provides a service that allows you to register and interact with a main camera in the game. This can be really helpful, if you need to access the camera from a behaviour or script. The corresponding manager can for example be used to enable or disable the camera. Please note: The module is called Video (and not Camera), because of a name collision with Unity's *Camera* class.

## VideoService

Create a new video service:

```
var videoService = new VideoService(myCamera);
```

Enable or disable the camera:

```
videoService.DisableCamera();
videoService.EnableCamera();
```

Enable or disable the audio listener:

```
videoService.DisableAudioListener();
videoService.EnableAudioListener();
```

## VideoManager

### Settings

- **camera** The camera this manager should control.
