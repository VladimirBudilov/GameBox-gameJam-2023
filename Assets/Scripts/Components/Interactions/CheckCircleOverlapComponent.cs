using System;
using UnityEngine;
using UnityEngine.Events;

namespace Components.Interactions
{
    public class CheckCircleOverlapComponent : MonoBehaviour
    {
        [SerializeField] private float _interactionRange;
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private OnOverlapEvent _onOverlap;

        private readonly Collider2D[] _interactionResult = new Collider2D[10];

        public void Check()
        {
            var size = Physics2D.OverlapCircleNonAlloc(
                transform.position,
                _interactionRange,
                _interactionResult,
                _layerMask);

            for (int i = 0; i < size; i++)
            {
                _onOverlap?.Invoke(_interactionResult[i].gameObject);
            }
        }
    }

    [Serializable]
    public class OnOverlapEvent : UnityEvent<GameObject> { }
}