using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aureola.Screenshot
{
    public class ScreenshotManager : MonoBehaviour
    {
        private static ScreenshotService _service;

        [Header("Settings")]
        [SerializeField] private KeyCode _key;
        [SerializeField] private string _folder = "my-folder";

        [Header("Automation")]
        [SerializeField] private bool _automated = false;
        [SerializeField] private float _automatedInterval = 1f;

        public static ScreenshotService service
        {
            get => _service;
        }

        private void Awake()
        {
            _service = new ScreenshotService(_folder);
        }

        private void OnEnable()
        {
            if (_automated) {
                StartCoroutine(AutoScreenshot());
            }
        }

        private void OnDisable()
        {
            if (_automated) {
                StopCoroutine(AutoScreenshot());
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(_key)) {
                _service.CaptureScreenshot();
            }
        }

        private IEnumerator AutoScreenshot()
        {
            while (true) {
                _service.CaptureScreenshot();
                yield return new WaitForSeconds(_automatedInterval);
            }
        }

        [ContextMenu("Capture Screenshot")]
        private void CaptureScreenshot()
        {
            _service.CaptureScreenshot();
        }
    }
}
