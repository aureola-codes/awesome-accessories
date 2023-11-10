using UnityEngine;

namespace Aureola.Scenes
{
    [CreateAssetMenu(fileName = "SceneExiting", menuName = "Aureola/Events/SceneExiting")]
    public class SceneExitingEvent : ScriptableObject
    {
        public delegate void SceneExiting(string sceneName);
        private event SceneExiting _onSceneExiting;

        public void Subscribe(SceneExiting callback)
        {
            _onSceneExiting += callback;
        }

        public void Unsubscribe(SceneExiting callback)
        {
            _onSceneExiting -= callback;
        }

        public void Invoke(string sceneName)
        {
            _onSceneExiting?.Invoke(sceneName);
        }
    }
}
