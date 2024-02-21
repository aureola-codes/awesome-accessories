using Aureola.Config;
using TMPro;
using UnityEngine;

namespace Aureola.Examples
{
    public class ConfigController : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private TextMeshProUGUI _output;

        [Header("Dependencies")]
        [SerializeField] private ConfigManager _configManager;

        private void Start()
        {
            _configManager.OnLoaded += OnConfigLoaded;
            _configManager.Load();
        }

        private void OnConfigLoaded()
        {
            _output.text = "Config loaded!\n\n";
            _output.text += "example_integer: " + _configManager.Get("example_integer", 0) + "\n";
            _output.text += "example_float: " + _configManager.Get("example_float", 0f) + "\n";
            _output.text += "example_string: " + _configManager.Get("example_string", "") + "\n";
            _output.text += "example_bool: " + _configManager.Get("example_bool", false) + "\n";

            _output.text += "example_vector2: " + _configManager.Get("example_vector2", Vector2.zero) + "\n";
            _output.text += "example_vector2_object: " + _configManager.Get("example_vector2_object", Vector2.zero) + "\n";

            _output.text += "example_vector3: " + _configManager.Get("example_vector3", Vector3.zero) + "\n";
            _output.text += "example_vector3_object: " + _configManager.Get("example_vector3_object", Vector3.zero) + "\n";

            _output.text += "example_quaternion: " + _configManager.Get("example_quaternion", Quaternion.identity) + "\n";
            _output.text += "example_quaternion_object: " + _configManager.Get("example_quaternion_object", Quaternion.identity) + "\n";

            _output.text += "example_color: " + _configManager.Get("example_color", Color.white) + "\n";
            _output.text += "example_hex_color: " + _configManager.Get("example_hex_color", Color.white) + "\n";
            _output.text += "example_rgba_color: " + _configManager.Get("example_rgba_color", Color.white) + "\n";
        }
    }
}
