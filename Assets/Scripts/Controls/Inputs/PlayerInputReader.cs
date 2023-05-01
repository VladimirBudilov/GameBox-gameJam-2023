using Components.Interactions;
using Components.Movement;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Controls.Inputs
{
    [RequireComponent(typeof(PlayerMovementComponent))]
    [RequireComponent(typeof(PlayerInteractComponent))]
    public class PlayerInputReader : MonoBehaviour
    {
        private PlayerInteractComponent _playerInteractComponent;
        private PlayerMovementComponent _playerMovementComponent;

        private void Awake()
        {
            _playerMovementComponent = GetComponent<PlayerMovementComponent>();
            _playerInteractComponent = GetComponent<PlayerInteractComponent>();
        }

        public void Move(InputAction.CallbackContext context)
        {
            _playerMovementComponent.Direction = context.ReadValue<float>();
        }

        public void Jump(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                _playerMovementComponent.IsJumpPressing = true;
            }

            if (context.canceled)
            {
                _playerMovementComponent.IsJumpPressing = false;
                _playerMovementComponent.JumpButtonWasPressed = false;
            }
        }

        public void Interact(InputAction.CallbackContext context)
        {
            if (context.started) _playerInteractComponent.Interact();
        }
    }
}