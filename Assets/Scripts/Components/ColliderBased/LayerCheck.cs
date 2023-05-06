using UnityEditor;
using UnityEngine;

namespace Components.ColliderBased
{
    [RequireComponent(typeof(CircleCollider2D))]
    public class LayerCheck : MonoBehaviour
    {
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private bool _isTouchingLayer;

        private CircleCollider2D _collider;

        public bool IsTouchingLayer => _isTouchingLayer;

        private void Start()
        {
            _collider = GetComponent<CircleCollider2D>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (_collider != null)
                _isTouchingLayer = _collider.IsTouchingLayers(_layerMask);
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (_collider != null)
                _isTouchingLayer = _collider.IsTouchingLayers(_layerMask);
        }


#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            if (_collider == null) return;
            Handles.color = IsTouchingLayer ? Color.green : Color.red;
            var offset = _collider.offset;
            var position = transform.position + new Vector3(offset.x, offset.y, 0);
            Handles.DrawSolidDisc(position, Vector3.forward, _collider.radius);
        }
#endif
    }
}