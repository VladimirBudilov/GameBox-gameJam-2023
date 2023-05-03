using Components.GameplayObjects.Creatures;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Controls.Inputs
{
    [RequireComponent(typeof(Player))]
    public class PlayerInputReader : MonoBehaviour
    {
        private Player _player;

        private void Awake()
        {
            _player = GetComponent<Player>();
        }

        public void Move(InputAction.CallbackContext context)
        {
            _player.MovementComponent.Direction = context.ReadValue<float>();
        }

        public void Jump(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                _player.MovementComponent.IsJumpPressing = true;
            }

            if (context.canceled)
            {
                _player.MovementComponent.IsJumpPressing = false;
                _player.MovementComponent.JumpButtonWasPressed = false;
            }
        }

        public void Interact(InputAction.CallbackContext context)
        {
            if (context.started) _player.InteractComponent.Interact();
        }

        public void RopeMovement(InputAction.CallbackContext context)
        {
            _player.RopeMovementComponent.Direction = context.ReadValue<Vector2>();
        }
    }
}