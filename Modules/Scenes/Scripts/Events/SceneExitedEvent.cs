using UnityEngine;

namespace Aureola.Scenes
{
    [CreateAssetMenu(fileName = "SceneExited", menuName = "Aureola/Events/SceneExited")]
    public class SceneExitedEvent : ScriptableObject
    {
        public delegate void SceneExited(string sceneName);
        private event SceneExited _onSceneExited;

        public void Subscribe(SceneExited callback)
        {
            _onSceneExited += callback;
        }

        public void Unsubscribe(SceneExited callback)
        {
            _onSceneExited -= callback;
        }

        public void Invoke(string sceneName)
        {
            _onSceneExited?.Invoke(sceneName);
        }
    }
}
