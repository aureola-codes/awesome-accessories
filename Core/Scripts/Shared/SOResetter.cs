using UnityEngine;

namespace Aureola
{
    public class SOResetter : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private bool _debug = false;
        [SerializeField] private bool _editorOnly = true;

        private void Awake()
        {
            if (_editorOnly && !Application.isEditor) {
                return;
            }

            // Find all scriptable objects in the project.
            ScriptableObject[] scriptableObjects = Resources.FindObjectsOfTypeAll<ScriptableObject>();

            // Loop through all scriptable objects.
            foreach (ScriptableObject scriptableObject in scriptableObjects) {
                // If the scriptable object is a resettable object.
                if (scriptableObject is IResettable) {
                    ((IResettable) scriptableObject).Reset();
                    if (_debug) {
                        Debug.Log("SOResetter: " + scriptableObject.name);
                    }
                }
            }
        }
    }
}
