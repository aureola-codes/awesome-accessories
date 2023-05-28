using Aureola.Interface;
using UnityEngine;

namespace Aureola.Scenes
{
    public class SceneButton : ClickableButton
    {
        [Header("Settings")]
        [SerializeField] [Scene] public string _sceneName;

        public void LoadScene()
        {
            if (_sceneName == null) {
                Debug.LogWarning("No scene selected.");
                return;
            }

            ScenesManager.instance?.ChangeTo(_sceneName);
        }
    }
}
