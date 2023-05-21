


namespace Aureola.Accessories
{
    public class ExitSceneButton : ClickableButton
    {
        public void OnClick()
        {
            ScenesManager.instance?.Exit(gameObject.scene.name);
        }
    }
}
