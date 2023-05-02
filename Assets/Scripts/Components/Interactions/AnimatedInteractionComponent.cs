using UnityEngine;
using UnityEngine.Events;

namespace Components.Interactions
{
    public class AnimatedInteractionComponent : MonoBehaviour, IInteractable
    {
        [SerializeField] private UnityEvent _interactAction;
        [SerializeField] private string _animationName;
        [SerializeField] private bool _isFireflyCanUse;
        public UnityEvent InteractAction => _interactAction;
        public bool IsFireflyCanUse => _isFireflyCanUse;
        public string AnimationName => _animationName;
    }
}