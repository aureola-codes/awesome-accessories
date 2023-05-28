using Aureola.Interface;
using UnityEngine;

namespace Aureola.Scenes
{
    public class ModalButton : ClickableButton
    {
        [SerializeField] [Scene] private string _sceneName;

        public void LoadScene()
        {
            if (_sceneName == null) {
                Debug.LogWarning("No scene selected.");
                return;
            }

            ScenesManager.instance?.Load(_sceneName);
        }
    }
}
