using UnityEngine;

namespace Aureola.Scenes
{
    [RequireComponent(typeof(Animator))]
    public class SceneBehaviour : MonoBehaviour
    {
        private const int ANIMATION_ENTER = 1;
        private const int ANIMATION_EXIT = -1;

        private Animator _animator;

        [Header("Dependencies")]
        [SerializeField] private ScenesManager _scenesManager;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            if (_scenesManager == null) {
                _scenesManager = SOLocator.Get<ScenesManager>();
            }
        }

        private void Start()
        {
            AnimationEnter();
        }

        private void OnAnimationEnterFinished()
        {
            _scenesManager.MarkSceneLoaded();
        }

        private void OnAnimationExitFinished()
        {   
            _scenesManager.UnloadScene();
        }

        public void AnimationEnter()
        {
            if (_animator != null) {
                _animator.SetInteger("animation", ANIMATION_ENTER);
            } else {
                OnAnimationEnterFinished();
            }
        }

        public void AnimationExit()
        {
            if (_animator != null) {
                _animator.SetInteger("animation", ANIMATION_EXIT);
            } else {
                OnAnimationExitFinished();
            }
        }
    }
}
