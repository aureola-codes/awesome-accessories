# Scenes

The `Scenes` module provides a set of utilities for managing scenes in Unity. It is built on top of Unity's built-in scene management and provides a more convenient way to load and unload scenes.

## ScenesManager

The ScenesManager class is designed to manage scene operations such as loading, exiting, and transitioning between scenes in a Unity project. It allows for asynchronous scene loading and unloading, with support for additive scenes. The class also provides events for scene operations, enabling custom behaviors during scene transitions.

### Methods

- `Load(string sceneName)` Initiates loading of a specified scene.
- `Exit(string sceneName)` Initiates exiting of a specified scene.
- `ExitAll()` Exits all currently loaded scenes.
- `ExitAllLike(string value)` Exits all scenes that start with the specified value.
- `ExitAllExcept(string value)` Exits all scenes except the one specified.
- `ChangeTo(string sceneName)` Changes to the specified scene, exiting all others.
- `IsSceneActive(string sceneName)` Checks if a scene is currently active.
- `IsCurrentScene(string sceneName)` Checks if the specified scene is the current scene.
- `GetCurrentScene()` Returns the name of the current scene.
- `Reset()` Resets the ScenesManager, clearing all operations and scenes.

### Events

- `OnSceneExited` Triggered after a scene has been exited.
- `OnSceneExiting` Triggered before a scene is exited.
- `OnSceneLoaded` Triggered after a scene has been loaded.
- `OnSceneLoading` Triggered before a scene is loaded.

### Example Usages

**Loading a Scene**

```csharp
public ScenesManager scenesManager; // Assume this is already assigned through the inspector or elsewhere

void Start() {
    scenesManager.Load("GameScene");
}
```

**Exiting a Scene**

```csharp
public void ExitScene() {
    scenesManager.Exit("MenuScene");
}
```

**Changing to a New Scene**

```csharp
public void ChangeScene() {
    scenesManager.ChangeTo("NewGameScene");
}
```

**Exiting All Scenes Except One**

```csharp
public void KeepOnlyMainScene() {
    scenesManager.ExitAllExcept("MainScene");
}
```

**Subscribing to Scene Events**

```csharp
void OnEnable() {
    scenesManager.OnSceneLoading += SceneLoading;
    scenesManager.OnSceneLoaded += SceneLoaded;
}

void SceneLoading(string sceneName) {
    Debug.Log("Loading scene: " + sceneName);
}

void SceneLoaded(string sceneName) {
    Debug.Log("Scene loaded: " + sceneName);
}

void OnDisable() {
    scenesManager.OnSceneLoading -= SceneLoading;
    scenesManager.OnSceneLoaded -= SceneLoaded;
}
```

### Behaviours

- `ExitScene` Exits the scene the behaviour is attached to.
- `LoadScene` Loads a specified scene.
- `OpenModal` Opens a modal scene on top of the current scene.
- `SceneBehaviour` Use this behaviour in your scene if you want to register animations for scene transitions.

---

**Example:** [/Examples/ScenesManager](/Examples/ScenesManager)
