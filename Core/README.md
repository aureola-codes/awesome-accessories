# Core

The core module contains the basic building blocks for the package. The following classes are included (besides others):

## Coworker

Scriptable Objects can't use coroutines directly. Instead we are using a simple MonoBehaviour for this.

Usage:

```csharp
Coworker.Instance.StartCoroutine(SomeCoroutine());
[...]
Coworker.Instance.StopCoroutine(SomeCoroutine());
```

**Warning:** Do not use `StopAllCoroutines()` as it will stop all coroutines making use of the Coworker.

## SOLocator

A simple service locator for Scriptable Objects.

Usage:

```csharp
var manager = SOLocator.Get<MyOwnManager>();
```

For this to work the manager needs to implement the `ILocatable` interface.

```csharp
public class MyOwnManager : ScriptableObject, ILocatable
{
    [...]
}
```

## SOResetter

Will make sure that Scriptable Objects are properly reset when entering play mode.

Usage:

For this to work the manager needs to implement the `IResettable` interface.

```csharp
public class MyOwnManager : ScriptableObject, IResettable
{
    public void Reset()
    {
        // Reset the manager.
    }
}
```
