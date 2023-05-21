


using UnityEngine;

namespace Aureola.Accessories
{
    public class SceneButton : ClickableButton
    {
        [SerializeField] private bool _isModal = false;
        [Scene] public string sceneName;

        public void LoadScene()
        {
            if (sceneName == null) {
                Debug.LogWarning("No scene selected.");
                return;
            }

            if (_isModal) {
                ScenesManager.instance?.Exit(gameObject.scene.name);
            }
            
            ScenesManager.instance?.ChangeTo(sceneName);
        }
    }
}
