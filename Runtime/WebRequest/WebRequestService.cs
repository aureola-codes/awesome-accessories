using System.Text;
using UnityEngine.Networking;

namespace Aureola.WebRequest
{
    public class WebRequestService
    {
        public delegate void OnSuccess(string responseBody);
        public delegate void OnFailure(string errorMessage);

        public OnSuccess onSuccess;
        public OnFailure onFailure;

        public void Send(WebRequestData data)
        {
            UnityWebRequest request = new UnityWebRequest(data.url, data.GetMethod());
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

            var asyncOperation = request.SendWebRequest();
            while (!asyncOperation.isDone) {
                // Just wait a little...
            }

            if (request.responseCode == 200 || request.responseCode == 201) {
                onSuccess.Invoke(request.downloadHandler.text);
            } else {
                onFailure.Invoke(request.error + ": " + request.downloadHandler.text);
            }
        }
    }
}
