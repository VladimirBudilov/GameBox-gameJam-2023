using UnityEngine;
using UnityEngine.Events;

namespace Components.Interactions
{
    public class InteractableComponent : MonoBehaviour, IInteractable
    {
        [SerializeField] private UnityEvent _action;
        [SerializeField] private bool _isFireflyCanUse;

        public UnityEvent InteractAction => _action;
        public bool IsFireflyCanUse => _isFireflyCanUse;
    }
}