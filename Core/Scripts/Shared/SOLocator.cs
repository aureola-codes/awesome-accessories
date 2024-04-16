using System;
using System.Collections.Generic;
using UnityEngine;

namespace Aureola
{
    public class SOLocator : MonoBehaviour
    {
        private static SOLocator _instance;
        private Dictionary<Type, ScriptableObject> _services = new();

        [Header("Settings")]
        [SerializeField] private bool _debug = false;

        public static SOLocator Instance
        {
            get {
                if (_instance == null) {
                    _instance = new GameObject("SOLocator").AddComponent<SOLocator>();
                }

                return _instance;
            }
        }

        private void Awake()
        {
            // Find all scriptable objects in the project.
            ScriptableObject[] scriptableObjects = Resources.FindObjectsOfTypeAll<ScriptableObject>();

            // Loop through all scriptable objects.
            foreach (ScriptableObject scriptableObject in scriptableObjects) {
                // If the scriptable object is a locatable object.
                if (scriptableObject is ILocatable) {
                    Register(scriptableObject);
                    if (_debug) {
                        Debug.Log($"SOLocator: {scriptableObject.name} registered.");
                    }
                }
            }
        }

        public void Register(ScriptableObject service)
        {
            _services[service.GetType()] = service;
        }

        public void Unregister(ScriptableObject service)
        {
            _services.Remove(service.GetType());
        }
        
        public T Locate<T>() where T : ScriptableObject
        {
            if (_services.TryGetValue(typeof(T), out var service)) {
                return service as T;
            }

            return null;
        }

        public static void Register<T>(T service) where T : ScriptableObject
        {
            Instance.Register(service);
        }

        public static void Unregister<T>(T service) where T : ScriptableObject
        {
            Instance.Unregister(service);
        }

        public static T Get<T>() where T : ScriptableObject
        {
            return Instance.Locate<T>();
        }
    }
}
