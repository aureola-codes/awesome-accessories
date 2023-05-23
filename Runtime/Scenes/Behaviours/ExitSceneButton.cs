using Aureola.Interface;

namespace Aureola.Scenes
{
    public class ExitSceneButton : ClickableButton
    {
        public void OnClick()
        {
            ScenesManager.instance?.Exit(gameObject.scene.name);
        }
    }
}
