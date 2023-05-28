using Aureola.PubSub;
using UnityEngine;

namespace Aureola.WebRequest
{
    public class WebRequestManager : MonoBehaviour
    {
        private static WebRequestService _instance;

        public static WebRequestService instance
        {
            get => _instance;
        }

        private void Awake()
        {
            _instance = new WebRequestService();
            _instance.onSuccess += OnSuccess;
            _instance.onFailure += OnFailure;
        }

        private void OnSuccess(string data)
        {
            PubSubManager.instance?.Send(Channel.WEBREQUEST, new WebRequestSuccess(data));
        }

        private void OnFailure(string error)
        {
            PubSubManager.instance?.Send(Channel.WEBREQUEST, new WebRequestFailure(error));
        }
    }
}
