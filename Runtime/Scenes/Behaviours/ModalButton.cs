using Aureola.Accessories;
using UnityEngine;

namespace Aureola.Accessories
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
