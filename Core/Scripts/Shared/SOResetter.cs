using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aureola
{
    public class SOResetter : MonoBehaviour
    {
        private ScriptableObject[] _scriptableObjects;

        private void Awake()
        {
            // Find all scriptable objects in the project.
            _scriptableObjects = Resources.FindObjectsOfTypeAll<ScriptableObject>();

            // Loop through all scriptable objects.
            foreach (ScriptableObject scriptableObject in _scriptableObjects) {
                // If the scriptable object is a resettable object.
                if (scriptableObject is IResettable) {
                    ((IResettable) scriptableObject).Reset();
                    Debug.Log($"{scriptableObject.name} has been reset.");
                }
            }
        }
    }
}
