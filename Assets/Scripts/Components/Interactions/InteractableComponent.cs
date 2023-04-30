using UnityEngine;
using UnityEngine.Events;

namespace Components.Interactions
{
    public class InteractableComponent : MonoBehaviour, IInteractable
    {
        [SerializeField] private UnityEvent _action;

        public UnityEvent InteractAction =>
            _action;
    }
}