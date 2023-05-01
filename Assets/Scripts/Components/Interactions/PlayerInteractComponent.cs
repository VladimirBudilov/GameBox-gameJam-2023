using UnityEngine;

namespace Components.Interactions
{
    public class PlayerInteractComponent : MonoBehaviour
    {
        [Header("Checkers")] 
        [SerializeField] private CheckCircleOverlapComponent _interactCircle;

        public void Interact()
        {
            _interactCircle.Check();
        }
    }
}