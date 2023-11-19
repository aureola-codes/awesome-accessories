using UnityEngine;

namespace Aureola.Cache
{
    [CreateAssetMenu(fileName = "PlayerPrefsCache", menuName = "Aureola/Cache/PlayerPrefsCache")]
    public class PlayerPrefsCache : ScriptableObject, CacheInterface
    {
        public bool isReady => true;

        public void Set(string key, int value)
        {
            PlayerPrefs.SetInt(key, value);
        }

        public void Set(string key, float value)
        {
            PlayerPrefs.SetFloat(key, value);
        }

        public void Set(string key, string value)
        {
            PlayerPrefs.SetString(key, value);
        }

        public void Set(string key, bool value)
        {
            PlayerPrefs.SetInt(key, value ? 1 : 0);
        }

        public void Set(string key, Vector2 value)
        {
            PlayerPrefs.SetString(key, $"{value.x},{value.y}");
        }

        public void Set(string key, Vector3 value)
        {
            PlayerPrefs.SetString(key, $"{value.x},{value.y},{value.z}");
        }

        public void Set(string key, Vector4 value)
        {
            PlayerPrefs.SetString(key, $"{value.x},{value.y},{value.z},{value.w}");
        }

        public void Set(string key, Color value)
        {
            PlayerPrefs.SetString(key, $"{value.r},{value.g},{value.b},{value.a}");
        }

        public void Set(string key, Color32 value)
        {
            PlayerPrefs.SetString(key, $"{value.r},{value.g},{value.b},{value.a}");
        }

        public void Set(string key, Quaternion value)
        {
            PlayerPrefs.SetString(key, $"{value.x},{value.y},{value.z},{value.w}");
        }

        public int Get(string key, int defaultValue)
        {
            return PlayerPrefs.GetInt(key, defaultValue);
        }

        public float Get(string key, float defaultValue)
        {
            return PlayerPrefs.GetFloat(key, defaultValue);
        }

        public string Get(string key, string defaultValue)
        {
            return PlayerPrefs.GetString(key, defaultValue);
        }

        public bool Get(string key, bool defaultValue)
        {
            return PlayerPrefs.GetInt(key, defaultValue ? 1 : 0) == 1;
        }

        public Vector2 Get(string key, Vector2 defaultValue)
        {
            var split = PlayerPrefs.GetString(key, "").Split(',');
            if (split.Length != 2) {
                return defaultValue;
            }

            return new Vector2(float.Parse(split[0]), float.Parse(split[1]));
        }

        public Vector3 Get(string key, Vector3 defaultValue)
        {
            var split = PlayerPrefs.GetString(key, "").Split(',');
            if (split.Length != 3) {
                return defaultValue;
            }

            return new Vector3(float.Parse(split[0]), float.Parse(split[1]), float.Parse(split[2]));
        }

        public Vector4 Get(string key, Vector4 defaultValue)
        {
            var split = PlayerPrefs.GetString(key, "").Split(',');
            if (split.Length != 4) {
                return defaultValue;
            }

            return new Vector4(float.Parse(split[0]), float.Parse(split[1]), float.Parse(split[2]), float.Parse(split[3]));
        }

        public Color Get(string key, Color defaultValue)
        {
            var split = PlayerPrefs.GetString(key, "").Split(',');
            if (split.Length != 4) {
                return defaultValue;
            }

            return new Color(float.Parse(split[0]), float.Parse(split[1]), float.Parse(split[2]), float.Parse(split[3]));
        }

        public Color32 Get(string key, Color32 defaultValue)
        {
            var split = PlayerPrefs.GetString(key, "").Split(',');
            if (split.Length != 4) {
                return defaultValue;
            }

            return new Color32(byte.Parse(split[0]), byte.Parse(split[1]), byte.Parse(split[2]), byte.Parse(split[3]));
        }

        public Quaternion Get(string key, Quaternion defaultValue)
        {
            var split = PlayerPrefs.GetString(key, "").Split(',');
            if (split.Length != 4) {
                return defaultValue;
            }

            return new Quaternion(float.Parse(split[0]), float.Parse(split[1]), float.Parse(split[2]), float.Parse(split[3]));
        }

        public void Clear()
        {
            PlayerPrefs.DeleteAll();
        }
    }
}
