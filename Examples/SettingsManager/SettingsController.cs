using Aureola.Settings;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Aureola.Examples
{
    public class SettingsController : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private TMP_InputField _exampleA;
        [SerializeField] private TMP_Dropdown _exampleB;
        [SerializeField] private Toggle _exampleC;
        [SerializeField] private TextMeshProUGUI _output;

        [Header("Dependencies")]
        [SerializeField] private SettingsManager _settingsManager;

        private void OnEnable()
        {
            _settingsManager.OnLoaded += OnSettingsLoaded;
            _settingsManager.OnStored += OnSettingsStored;
            _settingsManager.OnChanged += OnSettingsChanged;
            _settingsManager.OnError += OnSettingsError;
        }

        private void OnDisable()
        {
            _settingsManager.OnLoaded -= OnSettingsLoaded;
            _settingsManager.OnStored -= OnSettingsStored;
            _settingsManager.OnChanged -= OnSettingsChanged;
            _settingsManager.OnError -= OnSettingsError;
        }

        private void OnSettingsLoaded()
        {
            Debug.Log("Settings loaded!");
            UpdateFormElements();
        }

        private void OnSettingsStored()
        {
            Debug.Log("Settings stored!");
        }

        private void OnSettingsChanged()
        {
            Debug.Log("Settings changed!");
            _output.text = _settingsManager.Data.ToJson();
        }

        private void OnSettingsError(string message)
        {
            Debug.LogError(message);
        }

        private void UpdateFormElements()
        {
            _exampleA.SetTextWithoutNotify(_settingsManager.Data.exampleA);
            _exampleB.SetValueWithoutNotify(_settingsManager.Get<int>("exampleB"));
            _exampleC.SetIsOnWithoutNotify(_settingsManager.Get<bool>("exampleC"));

            _output.text = _settingsManager.Data.ToJson();
        }

        public void OnFieldUpdated()
        {
            _settingsManager.Set("exampleA", _exampleA.text);
            _settingsManager.Set("exampleB", _exampleB.value);
            _settingsManager.Set("exampleC", _exampleC.isOn);
        }

        public void OnButtonLoad()
        {
            _settingsManager.Load();
        }

        public void OnButtonSave()
        {
            _settingsManager.Save();
        }

        public void OnButtonReset()
        {
            _settingsManager.Reset();
            UpdateFormElements();
        }
    }
}
