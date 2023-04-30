using UnityEngine;
using UnityEngine.InputSystem;

namespace Controllers
{
    public class FireInputReader : InputReader
    {
        [SerializeField] private FireMovements _movements;

        public override void Move(InputAction.CallbackContext context)
        {
        }
    }
}