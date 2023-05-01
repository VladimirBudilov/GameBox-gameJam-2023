using Components.Movement;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Controls.Inputs
{
    [RequireComponent(typeof(FireflyMovementComponent))]
    public class FireflyInputReader : MonoBehaviour
    {
        private FireflyMovementComponent _fireflyMovementComponent;

        private void Awake()
        {
            _fireflyMovementComponent = GetComponent<FireflyMovementComponent>();
        }

        public void Move(InputAction.CallbackContext context)
        {
            _fireflyMovementComponent.Direction = context.ReadValue<Vector2>();
        }
    }
}