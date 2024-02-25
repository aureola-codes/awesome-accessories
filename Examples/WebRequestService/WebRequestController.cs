using System;
using Aureola.WebRequest;
using TMPro;
using UnityEngine;

namespace Aureola.Examples
{
    public class WebRequestController : MonoBehaviour
    {
        private WebRequestService _webRequestService;

        [Header("References")]
        [SerializeField] private TextMeshProUGUI _output;

        private void Awake()
        {
            _webRequestService = new WebRequestService()
                .SetTimeout(10)
                .SetDebugging(true)
                .SetSuccessCallback(OnRequestSuccess)
                .SetFailureCallback(OnRequestFailure);
        }

        private void OnRequestSuccess(string response)
        {
            WriteLog("Request successful!");
        }

        private void OnRequestFailure(string error)
        {
            WriteLog("Request failed: " + error);
        }

        private void WriteLog(string text)
        {
            _output.text = DateTime.UtcNow.ToString("HH:mm:ss") + ": " + text + "\n" + _output.text;
        }

        public void SendGetRequest()
        {
            WriteLog("Sending GET request...");

            var data = new WebRequestData("https://www.example.com");
            _webRequestService.Send(data);
        }

        public void SendPostRequest()
        {
            WriteLog("Sending POST request...");

            var data = new WebRequestData("https://www.example.com", WebRequestMethod.POST, "{\"key\": \"value\"}");
            _webRequestService.Send(data);
        }

        public void SendPutRequest()
        {
            WriteLog("Sending PUT request...");

            var data = new WebRequestData("https://www.example.com", WebRequestMethod.PUT, "{\"key\": \"value\"}");
            _webRequestService.Send(data);
        }

        public void SendDeleteRequest()
        {
            WriteLog("Sending DELETE request...");

            var data = new WebRequestData("https://www.example.com", WebRequestMethod.DELETE);
            _webRequestService.Send(data);
        }
    }
}
