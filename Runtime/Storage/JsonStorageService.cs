using SimpleJSON;
using System.Collections.Generic;
using UnityEngine;

namespace Aureola.Storage
{
    public class JsonStorageService : IStorageService
    {
        private string _fileName;
        private FilesService _filesService;
        private Dictionary<string, object> _cache = new Dictionary<string, object>();

        public JsonStorageService(string fileName = "storage.json")
        {
            _filesService = new FilesService();
            Load();
        }

        public JsonStorageService(string basePath, string fileName = "storage.json")
        {
            _filesService = new FilesService(basePath);
            Load();
        }

        public void Set(string key, int value)
        {
            _cache[key] = value;
            Save();
        }

        public void Set(string key, float value)
        {
            _cache[key] = value;
            Save();
        }

        public void Set(string key, string value)
        {
            _cache[key] = value;
            Save();
        }

        public void Set(string key, bool value)
        {
            _cache[key] = value;
            Save();
        }

        public void Set(string key, Vector2 value)
        {
            _cache[key] = value;
            Save();
        }

        public void Set(string key, Vector3 value)
        {
            _cache[key] = value;
            Save();
        }

        public void Set(string key, Vector4 value)
        {
            _cache[key] = value;
            Save();
        }

        public void Set(string key, Color value)
        {
            _cache[key] = value;
            Save();
        }

        public void Set(string key, Color32 value)
        {
            _cache[key] = value;
            Save();
        }

        public void Set(string key, Quaternion value)
        {
            _cache[key] = value;
            Save();
        }

        public int Get(string key, int defaultValue)
        {
            if (!_cache.ContainsKey(key)) {
                return defaultValue;
            }

            return (int) _cache[key];
        }

        public float Get(string key, float defaultValue)
        {
            if (!_cache.ContainsKey(key)) {
                return defaultValue;
            }

            return (float) _cache[key];
        }

        public string Get(string key, string defaultValue)
        {
            if (!_cache.ContainsKey(key)) {
                return defaultValue;
            }

            return (string) _cache[key];
        }

        public bool Get(string key, bool defaultValue)
        {
            if (!_cache.ContainsKey(key)) {
                return defaultValue;
            }

            return (bool) _cache[key];
        }

        public Vector2 Get(string key, Vector2 defaultValue)
        {
            if (!_cache.ContainsKey(key)) {
                return defaultValue;
            }

            return (Vector2) _cache[key];
        }

        public Vector3 Get(string key, Vector3 defaultValue)
        {
            if (!_cache.ContainsKey(key)) {
                return defaultValue;
            }

            return (Vector3) _cache[key];
        }

        public Vector4 Get(string key, Vector4 defaultValue)
        {
            if (!_cache.ContainsKey(key)) {
                return defaultValue;
            }

            return (Vector4) _cache[key];
        }

        public Color Get(string key, Color defaultValue)
        {
            if (!_cache.ContainsKey(key)) {
                return defaultValue;
            }

            return (Color) _cache[key];
        }

        public Color32 Get(string key, Color32 defaultValue)
        {
            if (!_cache.ContainsKey(key)) {
                return defaultValue;
            }

            return (Color32) _cache[key];
        }

        public Quaternion Get(string key, Quaternion defaultValue)
        {
            if (!_cache.ContainsKey(key)) {
                return defaultValue;
            }

            return (Quaternion) _cache[key];
        }

        public void Clear()
        {
            _cache.Clear();
            Save();
        }

        public void Load()
        {
            if (!_filesService.Exists(_fileName)) {
                return;
            }

            var jsonObject = JSON.Parse(_filesService.LoadText(_fileName));

            _cache = new Dictionary<string, object>();
            foreach (var keyValuePair in jsonObject) {
                _cache[keyValuePair.Key] = keyValuePair.Value.Value;
            }
        }

        public void Save()
        {
            _filesService.Save(_fileName, JsonUtility.ToJson(_cache));
        }
    }
}
