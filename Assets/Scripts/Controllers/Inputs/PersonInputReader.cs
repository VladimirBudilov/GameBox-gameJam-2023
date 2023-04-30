using UnityEngine;
using UnityEngine.InputSystem;

namespace Controllers
{
    public class PersonInputReader : InputReader
    {
        [SerializeField] private PersonMovements _movements;

        public override void Move(InputAction.CallbackContext context)
        {
            _movements.Direction = context.ReadValue<float>();
        }

        public override void Jump(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                _movements.IsJumpPressing = true;
            }

            if (context.canceled)
            {
                _movements.IsJumpPressing = false;
            }
        }
    }
}