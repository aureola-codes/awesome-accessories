using UnityEngine;

namespace Aureola.Accessories
{
    public class SceneBehaviour : MonoBehaviour
    {
        private const int ANIMATION_ENTER = 1;
        private const int ANIMATION_EXIT = -1;

        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void Start()
        {
            AnimationEnter();
        }

        private void OnAnimationEnterFinished()
        {
            ScenesManager.instance?.MarkSceneLoaded();
        }

        private void OnAnimationExitFinished()
        {   
            ScenesManager.instance?.UnloadScene();
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
