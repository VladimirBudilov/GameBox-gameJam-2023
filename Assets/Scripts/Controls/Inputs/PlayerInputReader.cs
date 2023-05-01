using Components.Movement;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Controls.Inputs
{
    [RequireComponent(typeof(PlayerMovementComponent))]
    public class PlayerInputReader : MonoBehaviour
    {
        private PlayerMovementComponent _playerMovementComponent;

        private void Awake()
        {
            _playerMovementComponent = GetComponent<PlayerMovementComponent>();
        }

        public void Move(InputAction.CallbackContext context)
        {
            _playerMovementComponent.Direction = context.ReadValue<float>();
        }

        public void Jump(InputAction.CallbackContext context)
        {
            if (context.started) _playerMovementComponent.IsJumpPressing = true;

            if (context.canceled) _playerMovementComponent.IsJumpPressing = false;
        }
    }
}