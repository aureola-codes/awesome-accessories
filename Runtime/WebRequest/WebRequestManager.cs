using Aureola.PubSub;
using UnityEngine;

namespace Aureola.WebRequest
{
    public class WebRequestManager : MonoBehaviour
    {
        private static WebRequestService _service;

        public static WebRequestService service
        {
            get => _service;
        }

        private void Awake()
        {
            _service = new WebRequestService();
            _service.onSuccess += OnSuccess;
            _service.onFailure += OnFailure;
        }

        private void OnSuccess(string data)
        {
            PubSubManager.service?.Send(Channel.WEBREQUEST, new WebRequestSuccess(data));
        }

        private void OnFailure(string error)
        {
            PubSubManager.service?.Send(Channel.WEBREQUEST, new WebRequestFailure(error));
        }
    }
}
