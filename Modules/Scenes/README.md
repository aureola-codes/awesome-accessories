# Scenes

TODO

## ScenesObject

### Usage

Using the scene manager you can load scenes:

```
scenes.Load("MyScene");
```

All scenes will be loaded additively. This means that the current scene will not be unloaded. If you want to unload the scene, you must do this manually:

```
scenes.Exit("MyScene");
```

You can also exit scenes based on conditions.

To exit all scenes that begin with a certain name use:

```
scenes.ExitAllLike("MyScene");
```

To exit all scenes except a certain scene use:

```
scenes.ExitAllExcept("MyScene");
```

To exit all scenes use:

```
scenes.ExitAll();
```

There is also a helper method which will exit all scenes and load a new scene:

```
scenes.ChangeTo("MyScene");
```

All loading & unloading processes are done asynchronously.

**Please note:** When you want to use the Scenes module, you must only use the Scenes module. Do not use Unity SceneManagement directly. This will cause unexpected behaviour.

### Events

- **SceneLoading**: This event is fired when a scene is about to be loaded.
- **SceneLoaded**: This event is fired when a scene has been loaded.
- **SceneExiting**: This event is fired when a scene is about to be exited.
- **SceneExited**: This event is fired when a scene has been exited.

## Behaviours

### ExitSceneButton

This behaviour can be used to exit the currently active scene. It can be used on a button for example.

### ModalButton

This behaviour can be used to load a new scene additively without unloading the current scene. You would normally want to use this for modal windows. It can be used on a button for example.

### SceneBehaviour

This behaviour can be used to play enter & exit animations for scene changes. You would normally attach this to the parent GameObject of a scene. It will automatically play the enter animation when the scene is loaded and the exit animation when the scene is exited. 

To make this work you need to register an integer trigger in the animator called **animation**. The value of this trigger will be set to 1 when the scene is loaded and to -1 when the scene is exited. You can use this trigger to play the appropriate animation.

You will also need to call events in the animation to tell the ScenesManager that the animation has finished. There are two callbacks for this: OnAnimationEnterFinished and OnAnimationExitFinished.

### SceneButton

This behaviour can be used to load a new scene additively and unload all currently active scenes. It can be used on a button for example.
