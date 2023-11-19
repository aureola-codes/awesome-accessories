using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aureola.Loader
{
    public class LoaderService
    {
        private Dictionary<string, float> _progress = new Dictionary<string, float>();
        private float _totalProgress = 0;

        public delegate void OnProgress(float progress);
        public delegate void OnComplete();
        public OnProgress onProgress;
        public OnComplete onComplete;

        public float progress => _totalProgress;

        public void Add(string name)
        {
            _progress.Add(name, 0);
            Update();
        }

        public void Remove(string name)
        {
            _progress.Remove(name);
            Update();
        }

        public void SetProgress(string name, float progress)
        {
            _progress[name] = Mathf.Clamp01(progress);
            Update();
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
            Update();
        }

        private void Update()
        {
            CalculateProgress();
            BroadcastProgress();
        }

        private void CalculateProgress()
        {
            _totalProgress = 0;
            if (_progress.Count > 0) {
                float total = 0;
                foreach (var item in _progress) {
                    total += item.Value;
                }

                _totalProgress = total / _progress.Count;
            }
        }

        private void BroadcastProgress()
        {
            onProgress?.Invoke(_totalProgress);
            if (_totalProgress == 1) {
                onComplete?.Invoke();
            }
        }
    }
}
