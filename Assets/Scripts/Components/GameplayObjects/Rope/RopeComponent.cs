using Components.ColliderBased;
using UnityEngine;

namespace Components.GameplayObjects.Rope
{
    public class RopeComponent : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _hook;
        [SerializeField] private GameObject _linkPrefab;
        [SerializeField] private WeightComponent _weight;
        private int _links;
        
        public void GenerateRope(bool isRightCliff, int ropeDistanceInLinks, int startRopeForce)
        {
            _links = ropeDistanceInLinks;
            Rigidbody2D previousRb = _hook;
            for (int i = 0; i < _links; i++)
            {
                GameObject link = Instantiate(_linkPrefab, transform);
                HingeJoint2D joint = link.GetComponent<HingeJoint2D>();
                joint.connectedBody = previousRb;

                if (i < _links - 1)
                {
                    previousRb = link.GetComponent<Rigidbody2D>();
                }
                else
                {
                    _weight.ConnectRopeEnd(link.GetComponent<Rigidbody2D>());
                    _weight.PushWeight(isRightCliff ? Vector2.right : Vector2.left, startRopeForce);
                }
            }
        }
    }
}