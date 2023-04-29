using System;
using UnityEngine;
using UnityEngine.Events;
using Utils;

namespace Components.Physics
{
    public class EnterTriggerComponent : MonoBehaviour
    {
        [SerializeField] private LayerMask _layer = ~0;
        [SerializeField] private EnterEvent _action;

        private void OnTriggerEnter(Collider collision)
        {
            if (collision.gameObject.IsInLayer(_layer)) 
                _action?.Invoke(collision.gameObject);
        }

        [Serializable]
        public class EnterEvent : UnityEvent<GameObject>
        {
        }
    }
}