using Aureola.Interface;
using UnityEngine;

namespace Aureola.Scenes
{
    public class ModalButton : ClickableButton
    {
        [Scene] public string sceneName;

        public void LoadScene()
        {
            if (sceneName == null) {
                Debug.LogWarning("No scene selected.");
                return;
            }

            ScenesManager.instance?.Load(sceneName);
        }
    }
}
