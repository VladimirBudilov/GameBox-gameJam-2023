using Components.Interactions;
using Components.Movement;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Controls.Inputs
{
    [RequireComponent(typeof(FireflyMovementComponent))]
    [RequireComponent(typeof(PlayerInteractComponent))]
    public class FireflyInputReader : MonoBehaviour
    {
        private FireflyMovementComponent _fireflyMovementComponent;
        private PlayerInteractComponent _playerInteractComponent;

        private void Awake()
        {
            _fireflyMovementComponent = GetComponent<FireflyMovementComponent>();
            _playerInteractComponent = GetComponent<PlayerInteractComponent>();
        }

        public void Move(InputAction.CallbackContext context)
        {
            _fireflyMovementComponent.Direction = context.ReadValue<Vector2>();
        }

        public void Interact(InputAction.CallbackContext context)
        {
            if (context.started) _playerInteractComponent.Interact();
        }
    }
}