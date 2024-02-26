using UnityEngine;

namespace Aureola.Scenes
{
    public class LoadScene : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] [Scene] public string _sceneName;

        [Header("Dependencies")]
        [SerializeField] private ScenesManager _scenesManager;

        private void Awake()
        {
            if (_scenesManager == null) {
                _scenesManager = SOLocator.Get<ScenesManager>();
            }
        }

        public void Execute()
        {
            if (_sceneName == null) {
                Debug.LogWarning("No scene selected.");
                return;
            }

            _scenesManager.ChangeTo(_sceneName);
        }
    }
}
