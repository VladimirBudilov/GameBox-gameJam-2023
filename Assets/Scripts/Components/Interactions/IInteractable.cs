using UnityEngine.Events;

namespace Components.Interactions
{
    public interface IInteractable
    {
        UnityEvent InteractAction { get; }
        bool IsFireflyCanUse { get; }
    }
}
