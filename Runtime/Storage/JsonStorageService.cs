using Aureola.Files;
using SimpleJSON;
using System.Collections.Generic;
using UnityEngine;

namespace Aureola.Storage
{
    public class JsonStorageService
    {
        private string _fileName;
        private FileService _fileService;
        private Dictionary<string, object> _cache = new Dictionary<string, object>();

        public JsonStorageService(string fileName = "storage.json")
        {
            _fileService = new FileService();
            Load();
        }

        public JsonStorageService(string basePath, string fileName = "storage.json")
        {
            _fileService = new FileService(basePath);
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

        public int GetInt(string key, int defaultValue)
        {
            if (!_cache.ContainsKey(key)) {
                return defaultValue;
            }

            return (int) _cache[key];
        }

        public float GetFloat(string key, float defaultValue)
        {
            if (!_cache.ContainsKey(key)) {
                return defaultValue;
            }

            return (float) _cache[key];
        }

        public string GetString(string key, string defaultValue)
        {
            if (!_cache.ContainsKey(key)) {
                return defaultValue;
            }

            return (string) _cache[key];
        }

        public bool GetBool(string key, bool defaultValue)
        {
            if (!_cache.ContainsKey(key)) {
                return defaultValue;
            }

            return (bool) _cache[key];
        }

        public Vector2 GetVector2(string key, Vector2 defaultValue)
        {
            if (!_cache.ContainsKey(key)) {
                return defaultValue;
            }

            return (Vector2) _cache[key];
        }

        public Vector3 GetVector3(string key, Vector3 defaultValue)
        {
            if (!_cache.ContainsKey(key)) {
                return defaultValue;
            }

            return (Vector3) _cache[key];
        }

        public Vector4 GetVector4(string key, Vector4 defaultValue)
        {
            if (!_cache.ContainsKey(key)) {
                return defaultValue;
            }

            return (Vector4) _cache[key];
        }

        public Color GetColor(string key, Color defaultValue)
        {
            if (!_cache.ContainsKey(key)) {
                return defaultValue;
            }

            return (Color) _cache[key];
        }

        public Color32 GetColor32(string key, Color32 defaultValue)
        {
            if (!_cache.ContainsKey(key)) {
                return defaultValue;
            }

            return (Color32) _cache[key];
        }

        private void Load()
        {
            if (!_fileService.Exists(_fileName)) {
                return;
            }

            var jsonObject = JSON.Parse(_fileService.LoadText(_fileName));

            _cache = new Dictionary<string, object>();
            foreach (var keyValuePair in jsonObject) {
                _cache[keyValuePair.Key] = keyValuePair.Value.Value;
            }
        }

        private void Save()
        {
            _fileService.Save(_fileName, JsonUtility.ToJson(_cache));
        }
    }
}
