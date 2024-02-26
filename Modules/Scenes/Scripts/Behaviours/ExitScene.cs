using UnityEngine;

namespace Aureola.Scenes
{
    public class ExitScene : MonoBehaviour
    {
        [Header("Dependencies")]
        [SerializeField] private ScenesManager _scenesManager;

        private void Awake()
        {
            if (_scenesManager == null) {
                _scenesManager = SOLocator.Get<ScenesManager>();
            }
        }

        public void Execute()
        {
            _scenesManager.Exit(gameObject.scene.name);
        }
    }
}
