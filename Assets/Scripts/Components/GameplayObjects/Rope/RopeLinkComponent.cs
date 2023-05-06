using Model;
using Pause;
using UnityEngine;

namespace Components.GameplayObjects.Rope
{
    public class RopeLinkComponent : MonoBehaviour, IPauseHandler
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private Rigidbody2D _previousSegment;
        [SerializeField] private Rigidbody2D _nextSegment;
        private PauseManager Pause => GameSession.Instance.PauseManager;

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
        private void OnEnable()
        {
            Pause.Register(this);
        }

        public void SetPaused(bool isPaused)
        {
            _rigidbody.simulated = !isPaused;
        }

        private void OnDestroy()
        {
            Pause.UnRegister(this);
        }
    }
}