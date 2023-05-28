# Storage

This module contains several storage services that can be used to store data locally on the device or during runtime. The following storage services are available:

- **JsonStorageService** This service can be used to store data in a JSON file.
- **SimpleStorageService** This service can be used to store data using Unity's PlayerPrefs.
- **RuntimeStorageService** This service can be used to store data during runtime.

All storage services must implement the **IStorageService** interface. This interface defines the following methods:

- **Set(string key, int value)** This method can be used to store an integer value.
- **Set(string key, float value)** This method can be used to store a float value.
- **Set(string key, string value)** This method can be used to store a string value.
- **Set(string key, bool value)** This method can be used to store a boolean value.
- **Set(string key, Vector2 value)** This method can be used to store a Vector2 value.
- **Set(string key, Vector3 value)** This method can be used to store a Vector3 value.
- **Set(string key, Vector4 value)** This method can be used to store a Vector4 value.
- **Set(string key, Color value)** This method can be used to store a Color value.
- **Set(string key, Color32 value)** This method can be used to store a Color32 value.
- **Set(string key, Quaternion value)** This method can be used to store a Quaternion value.
- **Get(string key, int defaultValue)** This method can be used to get an integer value.
- **Get(string key, float defaultValue)** This method can be used to get a float value.
- **Get(string key, string defaultValue)** This method can be used to get a string value.
- **Get(string key, bool defaultValue)** This method can be used to get a boolean value.
- **Get(string key, Vector2 defaultValue)** This method can be used to get a Vector2 value.
- **Get(string key, Vector3 defaultValue)** This method can be used to get a Vector3 value.
- **Get(string key, Vector4 defaultValue)** This method can be used to get a Vector4 value.
- **Get(string key, Color defaultValue)** This method can be used to get a Color value.
- **Get(string key, Color32 defaultValue)** This method can be used to get a Color32 value.
- **Get(string key, Quaternion defaultValue)** This method can be used to get a Quaternion value.
- **Clear()** This method can be used to clear all stored values.

## JsonStorageService

Create a new instance of the service:

```
var jsonStorageService = new JsonStorageService(filename);
```

## JsonStorageManager

### Settings

- **basePath** The base path where the JSON files are stored. Default: Application.persistentDataPath
- **filename** The filename of the JSON file. Default: storage.json

## SimpleStorageService

Create a new instance of the service:

```
var simpleStorageService = new SimpleStorageService();
```

## SimpleStorageManager

This manager does not have any settings.

## RuntimeStorageService

Create a new instance of the service:

```
var runtimeStorageService = new RuntimeStorageService();
```

## RuntimeStorageManager

This manager does not have any settings.
