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

        public void OnMove(InputAction.CallbackContext context)
        {
            _player.MovementComponent.Direction = context.ReadValue<float>();
        }

        public void OnJump(InputAction.CallbackContext context)
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

        public void OnInteract(InputAction.CallbackContext context)
        {
            if (context.started) _player.InteractComponent.Interact();
        }

        public void OnRopeMovement(InputAction.CallbackContext context)
        {
            _player.RopeMovementComponent.Direction = context.ReadValue<Vector2>();
        }

        public void OnReleaseRope(InputAction.CallbackContext context)
        {
            if (context.started) _player.RopeMovementComponent.ReleaseRope();
        }

        public void OnJumpOffRope(InputAction.CallbackContext context)
        {
            if (context.started) _player.RopeMovementComponent.JumpOff();
        }
    }
}