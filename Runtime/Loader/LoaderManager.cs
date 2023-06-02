using Aureola.PubSub;
using UnityEngine;

namespace Aureola.Loader
{
    public class LoaderManager : MonoBehaviour
    {
        private static LoaderService _service;

        public static LoaderService service
        {
            get => _service;
        }

        private void Awake()
        {
            _service = new LoaderService();
            _service.onProgress += OnProgress;
            _service.onComplete += OnComplete;
        }

        private void OnProgress(float progress)
        {
            PubSubManager.service?.Send(Channel.LOADER, new LoaderProgress(progress));
        }

        private void OnComplete()
        {
            PubSubManager.service?.Send(Channel.LOADER, new LoaderComplete());
        }
    }
}
