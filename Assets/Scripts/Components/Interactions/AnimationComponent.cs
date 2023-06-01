using UnityEngine;
using UnityEngine.Events;

namespace Components.Interactions
{
    public class AnimationComponent : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        public Animator Animator => _animator;

        private UnityEvent _event;

        public UnityEvent Event
        {
            set
            {
                _event = value;
            }
        }
        
        public void OnAnimationComplete()
        {
            _event?.Invoke();
        }
    }
}