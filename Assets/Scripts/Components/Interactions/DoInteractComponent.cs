using UnityEngine;

namespace Components.Interactions
{
    [RequireComponent(typeof(AnimationComponent))]
    public class DoInteractComponent : MonoBehaviour
    {
        [SerializeField] private bool _isFirefly;
        private AnimationComponent _animationComponent;

        private void Awake()
        {
            _animationComponent = GetComponent<AnimationComponent>();
        }

        public void DoInteract(GameObject go)
        {
            var interactable = go.GetComponent<IInteractable>();
            if (interactable == null) return;
            
            if (_isFirefly && !interactable.IsFireflyCanUse) return;

            if (interactable is InteractableComponent)
            {
                interactable.InteractAction.Invoke();
            }
            else if (interactable is AnimatedInteractionComponent animatedInteractable)
            {
                if (_animationComponent != null)
                {
                    _animationComponent.Event = animatedInteractable.InteractAction;
                    _animationComponent.Animator.SetTrigger(animatedInteractable.AnimationName);
                }
                else
                {
                    interactable.InteractAction.Invoke();
                }
            }
        }
    }
}