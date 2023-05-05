using System.Collections.Generic;
using Components.ColliderBased;
using Model;
using UnityEngine;

namespace Components.GameplayObjects.Rope
{
    public class RopeComponent : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _hook;
        [SerializeField] private GameObject _linkPrefab;
        [SerializeField] private WeightComponent _weight;
        [SerializeField] private float _offsetMultiplier = .1f;
        [SerializeField] private LineRenderer _lineRenderer;
        private List<GameObject> _linksArray = new List<GameObject>();
        private bool _isRopeGenerated;
        private bool IsPaused => GameSession.Instance.PauseManager.IsPaused;

        public void GenerateRope(bool isRightCliff, int ropeDistanceInLinks, int startRopeForce)
        {
            var linksAmount = ropeDistanceInLinks;
            Rigidbody2D previousRb = _hook;
            for (int i = 0; i < linksAmount; i++)
            {
                var offset = isRightCliff ? Vector3.right : Vector3.left;
                offset += Vector3.up;
                offset *= _offsetMultiplier * i;

                GameObject link = Instantiate(_linkPrefab, transform);
                link.transform.position += offset;
                _linksArray.Add(link);
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

            _lineRenderer.positionCount = linksAmount + 1;

            for (int i = 0; i < linksAmount; i++)
            {
                var ropeLinkComponent = _linksArray[i].GetComponent<RopeLinkComponent>();
                ropeLinkComponent.IsGrabSideRight = isRightCliff;
                if (i != 0)
                {
                    ropeLinkComponent.PreviousSegment = _linksArray[i - 1].GetComponent<Rigidbody2D>();
                }

                if (i != linksAmount - 1)
                {
                    ropeLinkComponent.NextSegment = _linksArray[i + 1].GetComponent<Rigidbody2D>();
                }
            }

            _isRopeGenerated = true;
        }

        private void Update()
        {
            if (!_isRopeGenerated || IsPaused) return;
            _lineRenderer.SetPosition(0, _hook.transform.position);
            for (int i = 0; i < _linksArray.Count; i++)
            {
                _lineRenderer.SetPosition(i + 1, _linksArray[i].transform.position);
            }
        }
    }
}