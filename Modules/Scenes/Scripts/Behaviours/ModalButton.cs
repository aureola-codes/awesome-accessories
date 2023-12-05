using Aureola.Interface;
using UnityEngine;
using UnityEngine.UI;

namespace Aureola.Scenes
{
    [RequireComponent(typeof(Button))]
    [RequireComponent(typeof(ClickableButton))]
    public class ModalButton : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] [Scene] private string _sceneName;

        [Header("Dependencies")]
        [SerializeField] private ScenesManager _scenes;

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
