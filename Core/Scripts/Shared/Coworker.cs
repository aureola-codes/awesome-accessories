using UnityEngine;

namespace Aureola
{
    public class Coworker : MonoBehaviour
    {
        private static Coworker _instance;

        public static Coworker Instance
        {
            get {
                if (_instance == null) {
                    _instance = new GameObject("Coworker").AddComponent<Coworker>();
                }

                return _instance;
            }
        }

        private void Awake()
        {
            if (_instance == null) {
                _instance = this;
            } else if (_instance != this) {
                // Make sure there is only one instance of this class.
                Destroy(gameObject);
            }
        }
    }
}
