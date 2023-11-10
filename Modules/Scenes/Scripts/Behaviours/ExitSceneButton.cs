using Aureola.Interface;
using UnityEngine;

namespace Aureola.Scenes
{
    public class ExitSceneButton : ClickableButton
    {
        [Header("Dependencies")]
        [SerializeField] private ScenesObject _scenes;

        public void OnClick()
        {
            _scenes.Exit(gameObject.scene.name);
        }
    }
}
