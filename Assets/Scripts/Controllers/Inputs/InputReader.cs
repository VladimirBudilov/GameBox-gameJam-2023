using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

namespace Controllers
{
    public class InputReader : MonoBehaviour
    {
        public virtual void Move(InputAction.CallbackContext context)
        {
        }

        public virtual void Jump(InputAction.CallbackContext context)
        {
        }
    }
}