using Aureola.PubSub;
using UnityEngine;

namespace Aureola.Loader
{
    public class LoaderManager : MonoBehaviour
    {
        private static LoaderService _instance;

        public static LoaderService instance
        {
            get => _instance;
        }

        private void Awake()
        {
            _instance = new LoaderService();
            _instance.onProgress += OnProgress;
            _instance.onComplete += OnComplete;
        }

        private void OnProgress(float progress)
        {
            PubSubManager.instance?.Send(Channel.LOADER, new LoaderProgress(progress));
        }

        private void OnComplete()
        {
            PubSubManager.instance?.Send(Channel.LOADER, new LoaderComplete());
        }
    }
}
