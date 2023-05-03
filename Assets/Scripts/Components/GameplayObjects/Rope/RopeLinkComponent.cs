using Model;
using UnityEngine;

namespace Components.GameplayObjects.Rope
{
    public class RopeLinkComponent : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private Rigidbody2D _previousSegment;
        [SerializeField] private Rigidbody2D _nextSegment;
        public Rigidbody2D PreviousSegment
        {
            get => _previousSegment;
            set => _previousSegment = value;
        }
        public Rigidbody2D NextSegment
        {
            get => _nextSegment;
            set => _nextSegment = value;
        }
        public bool IsGrabSideRight { get; set; }

        public void InteractWithRope()
        {
            GameSession.Instance.Player.RopeMovementComponent.InteractWithRope(_rigidbody);
        }
    }
}