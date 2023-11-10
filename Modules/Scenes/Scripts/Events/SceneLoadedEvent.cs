using UnityEngine;

namespace Aureola.Scenes
{
    [CreateAssetMenu(fileName = "SceneLoaded", menuName = "Aureola/Events/SceneLoaded")]
    public class SceneLoadedEvent : ScriptableObject
    {
        public delegate void SceneLoaded(string sceneName);
        private event SceneLoaded _onSceneLoaded;

        public void Subscribe(SceneLoaded callback)
        {
            _onSceneLoaded += callback;
        }

        public void Unsubscribe(SceneLoaded callback)
        {
            _onSceneLoaded -= callback;
        }

        public void Invoke(string sceneName)
        {
            _onSceneLoaded?.Invoke(sceneName);
        }
    }
}
