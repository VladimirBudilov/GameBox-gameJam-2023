using UnityEngine;
using UnityEngine.Events;

namespace Components.Interactions
{
    public class AnimatedInteractionComponent : MonoBehaviour, IInteractable
    {
        [SerializeField] private UnityEvent _interactAction;
        [SerializeField] private string _animationName;
        public UnityEvent InteractAction => _interactAction;
        public string AnimationName => _animationName;
    }
}