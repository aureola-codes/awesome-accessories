using Aureola.Interface;

namespace Aureola.Scenes
{
    public class ExitSceneButton : ClickableButton
    {
        public void OnClick()
        {
            ScenesManager.service?.Exit(gameObject.scene.name);
        }
    }
}
