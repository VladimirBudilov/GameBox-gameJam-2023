using UnityEngine;

namespace Components.Interactions
{
    [RequireComponent(typeof(AnimationComponent))]
    public class DoInteractComponent : MonoBehaviour
    {
        private AnimationComponent _animationComponent;

        private void Awake()
        {
            _animationComponent = GetComponent<AnimationComponent>();
        }

        public void DoInteract(GameObject go)
        {
            var interactable = go.GetComponent<IInteractable>();
            if (interactable == null) return;

            if (interactable is InteractableComponent)
            {
                interactable.InteractAction.Invoke();
            }
            else if (interactable is AnimatedInteractionComponent animatedInteractable)
            {
                _animationComponent.Event = animatedInteractable.InteractAction;
                _animationComponent.Animator.SetTrigger(animatedInteractable.AnimationName);
            }
        }
    }
}