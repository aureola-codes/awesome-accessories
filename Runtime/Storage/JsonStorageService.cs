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

        public int GetInt(string key, int defaultValue = 0)
        {
            if (!_cache.ContainsKey(key)) {
                return defaultValue;
            }

            return (int)_cache[key];
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
