using UnityEngine;

namespace Aureola.Scenes
{
    [CreateAssetMenu(fileName = "SceneLoading", menuName = "Aureola/Events/SceneLoading")]
    public class SceneLoadingEvent : ScriptableObject
    {
        public delegate void SceneLoading(string sceneName);
        private event SceneLoading _onSceneLoading;

        public void Subscribe(SceneLoading callback)
        {
            _onSceneLoading += callback;
        }

        public void Unsubscribe(SceneLoading callback)
        {
            _onSceneLoading -= callback;
        }

        public void Invoke(string sceneName)
        {
            _onSceneLoading?.Invoke(sceneName);
        }
    }
}
