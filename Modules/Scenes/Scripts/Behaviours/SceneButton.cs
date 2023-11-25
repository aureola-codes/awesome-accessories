using Aureola.Interface;
using UnityEngine;
using UnityEngine.UI;

namespace Aureola.Scenes
{
    [RequireComponent(typeof(Button))]
    public class SceneButton : ClickableButton
    {
        [Header("Settings")]
        [SerializeField] [Scene] public string _sceneName;

        [Header("Dependencies")]
        [SerializeField] private ScenesManager _scenes;

        private void Awake()
        {
            GetComponent<Button>().onClick.AddListener(LoadScene);
        }

        public void LoadScene()
        {
            if (_sceneName == null) {
                Debug.LogWarning("No scene selected.");
                return;
            }

            _scenes.ChangeTo(_sceneName);
        }
    }
}
