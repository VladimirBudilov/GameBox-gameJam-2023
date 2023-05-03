using Components.ColliderBased;
using UnityEngine;

namespace Components.GameplayObjects.Rope
{
    public class RopeComponent : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _hook;
        [SerializeField] private GameObject _linkPrefab;
        [SerializeField] private WeightComponent _weight;

        //TODO: добавить LineRenderer чтобы получилась полноценная веревка
        public void GenerateRope(bool isRightCliff, int ropeDistanceInLinks, int startRopeForce)
        {
            var linksAmount = ropeDistanceInLinks;
            Rigidbody2D previousRb = _hook;
            GameObject[] linksArray = new GameObject[linksAmount];
            for (int i = 0; i < linksAmount; i++)
            {
                GameObject link = Instantiate(_linkPrefab, transform);
                linksArray[i] = link;
                HingeJoint2D joint = link.GetComponent<HingeJoint2D>();
                joint.connectedBody = previousRb;
                if (i < linksAmount - 1)
                {
                    previousRb = link.GetComponent<Rigidbody2D>();
                }
                else
                {
                    _weight.ConnectRopeEnd(link.GetComponent<Rigidbody2D>());
                    _weight.PushWeight(isRightCliff ? Vector2.right : Vector2.left, startRopeForce);
                }
            }

            for (int i = 0; i < linksAmount; i++)
            {
                var ropeLinkComponent = linksArray[i].GetComponent<RopeLinkComponent>();
                ropeLinkComponent.IsGrabSideRight = isRightCliff;
                if (i != 0)
                {
                    ropeLinkComponent.PreviousSegment = linksArray[i - 1].GetComponent<Rigidbody2D>();
                }

                if (i != linksAmount - 1)
                {
                    ropeLinkComponent.NextSegment = linksArray[i + 1].GetComponent<Rigidbody2D>();
                }
            }
        }
    }
}