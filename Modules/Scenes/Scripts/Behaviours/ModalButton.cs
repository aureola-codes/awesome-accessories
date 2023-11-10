using Aureola.Interface;
using UnityEngine;

namespace Aureola.Scenes
{
    public class ModalButton : ClickableButton
    {
        [Header("Settings")]
        [SerializeField] [Scene] private string _sceneName;

        [Header("Dependencies")]
        [SerializeField] private ScenesObject _scenes;

        public void LoadScene()
        {
            if (_sceneName == null) {
                Debug.LogWarning("No scene selected.");
                return;
            }

            _scenes.Load(_sceneName);
        }
    }
}
