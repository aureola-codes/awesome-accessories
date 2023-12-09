using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aureola
{
    public class SOResetter : MonoBehaviour
    {
        private void Awake()
        {
            if (!Application.isEditor) {
                return;
            }

            // Find all scriptable objects in the project.
            ScriptableObject[] scriptableObjects = Resources.FindObjectsOfTypeAll<ScriptableObject>();

            // Loop through all scriptable objects.
            foreach (ScriptableObject scriptableObject in scriptableObjects) {
                // If the scriptable object is a resettable object.
                if (scriptableObject is IResettable) {
                    ((IResettable) scriptableObject).Reset();
                    Debug.Log("SOResetter: " + scriptableObject.name);
                }
            }
        }
    }
}
