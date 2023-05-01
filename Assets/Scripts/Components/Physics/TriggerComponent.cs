using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using Utils;

namespace Components.Physics
{
    public class TriggerComponent : MonoBehaviour
    {
        [SerializeField] private LayerMask _layer = ~0;
        [SerializeField] private EnterEvent _EnterAction;
        [SerializeField] private EnterEvent _ExitAction;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.IsInLayer(_layer)) 
                _EnterAction?.Invoke(collision.gameObject);
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.IsInLayer(_layer)) 
                _ExitAction?.Invoke(collision.gameObject);
        }

        [Serializable]
        public class EnterEvent : UnityEvent<GameObject>
        {
        }
    }
}