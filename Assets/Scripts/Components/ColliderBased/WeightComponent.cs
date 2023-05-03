using UnityEngine;

namespace Components.ColliderBased
{
    public class WeightComponent : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private float _distanceFromChainEnd = .6f;

        public void ConnectRopeEnd(Rigidbody2D endRigidbody)
        {
            HingeJoint2D joint = gameObject.AddComponent<HingeJoint2D>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedBody = endRigidbody;
            joint.anchor = Vector2.zero;
            joint.connectedAnchor = new Vector2(0f, -_distanceFromChainEnd);
        }

        public void PushWeight(Vector2 direction, int startForce)
        {
            _rigidbody.AddForce((Vector2.up + direction) * startForce, ForceMode2D.Impulse);
        }
    }
}