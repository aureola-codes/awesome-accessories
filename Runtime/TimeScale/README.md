# TimeScale

The **TimeScale** module provides a service that allows you to control the time scale of your game.

## TimeScaleService

Create a new time scale service:

```
var timeScaleService = new TimeScaleService();
```

You can now pause the game:

```
timeScaleService.Pause();
```

You can then resume the game:

```
timeScaleService.Resume();
```

You can also set the time scale to a specific value:

```
timeScaleService.SetTimeScale(0.5f);
```

And you can check if the game is paused:

```
if (timeScaleService.IsPaused) {
  // Do stuff...
}
```

## Behaviours

### PauseWhenActive

Pauses the game, when the behaviour is enabled. Resumes the game, when the behaviour is disabled. Can be handy to pause the game, when a menu is opened or the player is looking at the inventory.
