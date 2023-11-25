using UnityEngine;
using TMPro;

namespace Aureola
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class Version : MonoBehaviour
    {
        private void Awake()
        {
            GetComponent<TextMeshProUGUI>().text = Application.unityVersion + "-" + Application.version;
        }
    }
}