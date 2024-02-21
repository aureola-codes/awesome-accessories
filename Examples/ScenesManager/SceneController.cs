using Aureola.Scenes;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Aureola.Examples
{
    public class SceneController : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] [Scene] private string _startScene;

        [Header("References")]
        [SerializeField] private EventSystem _eventSystem;

        [Header("Dependencies")]
        [SerializeField] private ScenesManager _scenesManager;

        private void Start()
        {
            _scenesManager.Load(_startScene);
        }
    }
}
