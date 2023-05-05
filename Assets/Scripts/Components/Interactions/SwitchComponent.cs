using Model;
using Pause;
using UnityEngine;

namespace Components.Interactions
{
    public class SwitchComponent : MonoBehaviour, IPauseHandler
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private bool _state;
        [SerializeField] private string _animationKey;
        private bool _isLocked;

        private void Start()
        {
            Animate();
            GameSession.Instance.PauseManager.Register(this);
        }

        public void Switch()
        {
            if (_isLocked) return;

            _state = !_state;
            Animate();
        }

        private void Animate()
        {
            _animator.SetBool(_animationKey, _state);
        }

        public void LockSwitching()
        {
            _isLocked = true;
        }

        [ContextMenu("Switch")]
        public void SwitchIt()
        {
            Switch();
        }

        public void SetPaused(bool isPaused)
        {
            _animator.speed = isPaused ? 0f : 1f;
        }

        private void OnDestroy()
        {
            GameSession.Instance.PauseManager.UnRegister(this);
        }
    }
}