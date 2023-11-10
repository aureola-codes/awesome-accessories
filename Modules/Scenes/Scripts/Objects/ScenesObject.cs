using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Aureola.Scenes
{
    [CreateAssetMenu(fileName = "Scenes", menuName = "Aureola/Shared/Scenes")]
    public class ScenesObject : ScriptableObject
    {
        private class Operation
        {
            public string scene;
            public OperationType type;
            public Operation(string newScene, OperationType newType) {
                scene = newScene;
                type = newType;
            }
        }

        private enum OperationType
        {
            Load,
            Exit
        }

        private string _processedScene;
        private List<Operation> _ops = new List<Operation>();
        private List<string> _scenes = new List<string>();

        [Header("Events")]
        [SerializeField] private SceneExitedEvent _onSceneExited;
        [SerializeField] private SceneExitingEvent _onSceneExiting;
        [SerializeField] private SceneLoadedEvent _onSceneLoaded;
        [SerializeField] private SceneLoadingEvent _onSceneLoading;

        public bool Load(string sceneName)
        {
            if (!IsValidScene(sceneName)) {
                Debug.LogWarning("Scene does not exist: " + sceneName);
                return false;
            }

            _ops.Add(new Operation(sceneName, OperationType.Load));

            NextOperation();
            return true;
        }

        public bool Exit(string sceneName)
        {
            if (!_scenes.Contains(sceneName)) {
                Debug.LogWarning("Scene not currently active: " + sceneName);
                return false;
            }

            _ops.Add(new Operation(sceneName, OperationType.Exit));

            NextOperation();
            return true;
        }

        public void ExitAll()
        {
            for (int i = _scenes.Count - 1; i >= 0; i--) {
                Exit(_scenes[i]);
            }
        }

        public void ExitAllLike(string value)
        {
            for (int i = _scenes.Count - 1; i >= 0; i--) {
                if (_scenes[i].StartsWith(value)) {
                    Exit(_scenes[i]);
                }
            }
        }

        public void ExitAllExcept(string value)
        {
            for (int i = _scenes.Count - 1; i >= 0; i--) {
                if (_scenes[i] != value) {
                    Exit(_scenes[i]);
                }
            }
        }

        public void ChangeTo(string sceneName)
        {
            if (Load(sceneName)) {
                ExitAllExcept(sceneName);
            }
        }

        public void MarkSceneLoaded() {
            _onSceneLoaded.Invoke(_processedScene);

            _scenes.Add(_processedScene);
            _processedScene = null;

            NextOperation();
        }

        public void MarkSceneExited() {
            _onSceneExited.Invoke(_processedScene);

            _scenes.Remove(_processedScene);
            _processedScene = null;

            NextOperation();
        }

        public void UnloadScene()
        {
            Coworker.Instance.StartCoroutine(UnloadScene(_processedScene));
        }

        public bool IsSceneActive(string sceneName)
        {
            return _scenes.Contains(sceneName);
        }

        public bool IsCurrentScene(string sceneName)
        {
            return GetCurrentScene() == sceneName;
        }

        public string GetCurrentScene()
        {
            if (_scenes.Count == 0) {
                return null;
            }

            return _scenes[_scenes.Count - 1];
        }

        private IEnumerator LoadScene(string sceneName)
        {
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
            while (!asyncLoad.isDone) {
                yield return null;
            }

            Debug.Log("Scene " + sceneName + " loaded.");

            SceneBehaviour sceneBehaviour = GetSceneBehaviour(sceneName);
            if (sceneBehaviour == null) {
                MarkSceneLoaded();
            }
        }

        private IEnumerator UnloadScene(string sceneName)
        {
            Scene scene = SceneManager.GetSceneByName(sceneName);
            if (scene.IsValid()) {
                AsyncOperation asyncLoad = SceneManager.UnloadSceneAsync(sceneName);
                while (!asyncLoad.isDone) {
                    yield return null;
                }

                Debug.Log("Scene " + sceneName + " unloaded.");
            }

            MarkSceneExited();
        }

        private SceneBehaviour GetSceneBehaviour(string sceneName)
        {
            Scene scene = SceneManager.GetSceneByName(sceneName);
            if (!scene.IsValid()) {
                return null;
            }

            foreach (var gameObject in scene.GetRootGameObjects()) {
                SceneBehaviour behaviour = gameObject.GetComponent<SceneBehaviour>();
                if (behaviour != null) {
                    return behaviour;
                }
            }

            return null;
        }

        private void NextOperation()
        {
            if (_processedScene != null) {
                return;
            }
            
            var operation = _ops[0];
            _ops.Remove(operation);

            _processedScene = operation.scene;

            if (operation.type == OperationType.Exit) {
                _onSceneExiting.Invoke(_processedScene);

                SceneBehaviour sceneBehaviour = GetSceneBehaviour(operation.scene);
                if (sceneBehaviour != null) {
                    sceneBehaviour.AnimationExit();
                } else {
                    UnloadScene();
                }
            } else {
                _onSceneLoading.Invoke(_processedScene);

                Coworker.Instance.StartCoroutine(LoadScene(operation.scene));
            }
        }

        private bool IsValidScene(string sceneName)
        {
            if (string.IsNullOrEmpty(sceneName)) {
                return false;
            }
                
            for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++) {
                var scenePath = SceneUtility.GetScenePathByBuildIndex(i);
                var lastSlash = scenePath.LastIndexOf("/");

                var scene = scenePath.Substring(lastSlash + 1, scenePath.LastIndexOf(".") - lastSlash - 1);
                if (string.Compare(sceneName, scene, true) == 0) {
                    return true;
                }
            }

            return false;
        }
    }
}
