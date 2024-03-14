using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

namespace Aureola.WebRequest
{
    public class WebRequestService
    {
        private int _timeout = 10;
        private bool _debugging = false;

        public delegate void Success(string responseBody);
        public Success OnSuccess;

        public delegate void Failure(string errorMessage);
        public Failure OnFailure;

        public WebRequestService SetTimeout(int timeout)
        {
            _timeout = timeout;
            return this;
        }

        public WebRequestService SetDebugging(bool debugging)
        {
            _debugging = debugging;
            return this;
        }

        public WebRequestService SetSuccessCallback(Success callback)
        {
            OnSuccess = callback;
            return this;
        }

        public WebRequestService SetFailureCallback(Failure callback)
        {
            OnFailure = callback;
            return this;
        }

        public void Send(WebRequestData data)
        {
            Coworker.Instance.StartCoroutine(SendRequest(data));
        }

        public void Send(string url)
        {
            Send(new WebRequestData(url));
        }

        public void Send(string url, WebRequestMethod method)
        {
            Send(new WebRequestData(url, method));
        }

        public void Send(string url, WebRequestMethod method, string payload)
        {
            Send(new WebRequestData(url, method, payload));
        }

        public void Send(string url, WebRequestMethod method, Dictionary<string, string> headers)
        {
            Send(new WebRequestData(url, method, headers));
        }

        public void Send(string url, WebRequestMethod method, Dictionary<string, string> headers, string payload)
        {
            Send(new WebRequestData(url, method, headers, payload));
        }

        private IEnumerator SendRequest(WebRequestData data)
        {
            UnityWebRequest request = new UnityWebRequest(data.url, data.GetMethod());

            request.timeout = _timeout;
            request.useHttpContinue = false;
            request.downloadHandler = (DownloadHandler) new DownloadHandlerBuffer();

            if (data.headers != null) {
                foreach (var header in data.headers) {
                    request.SetRequestHeader(header.Key, header.Value);
                }
            }

            if (data.payload != null) {
                byte[] payloadBytes = Encoding.UTF8.GetBytes(data.payload);
                request.uploadHandler = (UploadHandler) new UploadHandlerRaw(payloadBytes);
            }

            Log("Sending " + request.method + " request to " + request.url);
            yield return request.SendWebRequest();

            if (request.responseCode == 200 || request.responseCode == 201) {
                Log("Request successful! " + request.downloadHandler.text);
                OnSuccess?.Invoke(request.downloadHandler.text);
            } else {
                Log("Request failed! " + request.error + ": " + request.downloadHandler.text);
                OnFailure?.Invoke(request.error + ": " + request.downloadHandler.text);
            }

            request.Dispose();
        }

        private void Log(string message)
        {
            if (_debugging) {
                Debug.Log(message);
            }
        }
    }
}
