using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aureola.Loader
{
    public class LoaderService
    {
        private Dictionary<string, float> _progress = new Dictionary<string, float>();

        public delegate void OnProgress(float progress);
        public delegate void OnComplete();
        public OnProgress onProgress;
        public OnComplete onComplete;

        public float progress
        {
            get {
                float total = 0;
                foreach (var item in _progress) {
                    total += item.Value;
                }
                return total / _progress.Count;
            }
        }

        public void Add(string name)
        {
            _progress.Add(name, 0);
            Broadcast();
        }

        public void Remove(string name)
        {
            _progress.Remove(name);
            Broadcast();
        }

        public void SetProgress(string name, float progress)
        {
            _progress[name] = Mathf.Clamp01(progress);
            Broadcast();
        }

        public void Complete(string name)
        {
            SetProgress(name, 1);
        }

        public float GetProgress(string name)
        {
            return _progress.ContainsKey(name) ? _progress[name] : 0f;
        }

        public void Reset()
        {
            _progress.Clear();
            Broadcast();
        }

        private void Broadcast()
        {
            onProgress?.Invoke(progress);
            if (progress == 1) {
                onComplete?.Invoke();
            }
        }
    }
}
