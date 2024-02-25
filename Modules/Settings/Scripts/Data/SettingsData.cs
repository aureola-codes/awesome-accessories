using UnityEngine;

public partial class SettingsData
{
    public static SettingsData FromJson(string json)
    {
        return JsonUtility.FromJson<SettingsData>(json);
    }

    public string ToJson()
    {
        return JsonUtility.ToJson(this);
    }

    public void Set<T>(string key, T value)
    {
        var field = GetType().GetField(key);
        if (field != null && field.FieldType == typeof(T)) {
            field.SetValue(this, value);
        } else {
            Debug.LogError($"SettingsData.Set<{typeof(T)}>({key}, {value}) failed");
        }
    }

    public T Get<T>(string key)
    {
        var field = GetType().GetField(key);
        if (field != null && field.FieldType == typeof(T)) {
            return (T) field.GetValue(this);
        }

        return default;
    }
}
