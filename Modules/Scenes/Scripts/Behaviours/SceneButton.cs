using UnityEngine;

namespace Aureola.Scenes
{
    public class SceneButton : ClickableButton
    {
        [Header("Settings")]
        [SerializeField] [Scene] public string _sceneName;

        [Header("Dependencies")]
        [SerializeField] private ScenesObject _scenes;

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
