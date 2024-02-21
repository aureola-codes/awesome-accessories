using System;
using System.Collections.Generic;
using UnityEngine;

namespace Aureola
{
    public class SOLocator : MonoBehaviour
    {
        private static Dictionary<Type, ScriptableObject> _services = new Dictionary<Type, ScriptableObject>();

        private void Awake()
        {
            // Find all scriptable objects in the project.
            ScriptableObject[] scriptableObjects = Resources.FindObjectsOfTypeAll<ScriptableObject>();

            // Loop through all scriptable objects.
            foreach (ScriptableObject scriptableObject in scriptableObjects) {
                // If the scriptable object is a locatable object.
                if (scriptableObject is ILocatable) {
                    Register(scriptableObject);
                    Debug.Log("SOLocator: " + scriptableObject.name);
                }
            }
        }

        public static void Register<T>(T service) where T : ScriptableObject
        {
            _services[typeof(T)] = service;
        }

        public static void Unregister<T>(T service) where T : ScriptableObject
        {
            _services.Remove(typeof(T));
        }

        public static T Get<T>() where T : ScriptableObject
        {
            if (_services.TryGetValue(typeof(T), out var service)) {
                return service as T;
            }

            return null;
        }
    }
}
