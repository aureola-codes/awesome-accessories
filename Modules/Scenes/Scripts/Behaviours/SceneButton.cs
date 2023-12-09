using Aureola.Interface;
using UnityEngine;
using UnityEngine.UI;

namespace Aureola.Scenes
{
    [RequireComponent(typeof(Button))]
    [RequireComponent(typeof(ClickableButton))]
    public class SceneButton : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] [Scene] public string _sceneName;

        [Header("Dependencies")]
        [SerializeField] private ScenesManager _scenesManager;

        private void Awake()
        {
            GetComponent<Button>().onClick.AddListener(LoadScene);
            if (_scenesManager == null) {
                _scenesManager = SOLocator.Get<ScenesManager>();
            }
        }

        public void LoadScene()
        {
            if (_sceneName == null) {
                Debug.LogWarning("No scene selected.");
                return;
            }

            _scenesManager.ChangeTo(_sceneName);
        }
    }
}
