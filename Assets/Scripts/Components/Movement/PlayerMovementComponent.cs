using Components.ColliderBased;
using UnityEngine;
using Utils;

namespace Components.Movement
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovementComponent : MonoBehaviour
    {
        [Header("Settings fields")]
        [SerializeField] private Animator _animator;
        [SerializeField] private float _speed;
        [SerializeField] private float _jumpForce;
        [SerializeField] private float _deathHigh;

        [Space] [Header("Checkers")]
        [SerializeField] private DeathEvent _deathEvent;
        [SerializeField] private LayerCheck _groundCheck;

        [Space] [Header("UI")] 
        [SerializeField] private Transform _sanityBarCanvasTransform;

        private Rigidbody2D _rigidbody;
        private bool _isJumping;
        private bool _isGrounded;
        private bool _isDied;

        private static readonly int IS_RUNNING = Animator.StringToHash("is-running");

        public float Direction { get; set; }
        public bool IsJumpPressing { get; set; }
        public bool JumpButtonWasPressed { get; set; }
        public bool IsActive { get; set; }

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            IsActive = true;
        }

        private void Update()
        {
            if (_rigidbody.velocity.y <= -_deathHigh && !_isDied)
            {
                _isDied = true;
                _deathEvent?.Invoke("fall");
            }

            _isGrounded = _groundCheck.IsTouchingLayer;
        }

        private void FixedUpdate()
        {
            Debug.Log(IsActive);
            if (!IsActive) return;
            var velocity = CalculateVelocity();
            _rigidbody.velocity = velocity;

            UpdateSpriteDirection();
        }

        private Vector2 CalculateVelocity()
        {
            var xVelocity = CalculateXVelocity();
            var yVelocity = CalculateYVelocity();
            return new Vector2(xVelocity, yVelocity);
        }

        private float CalculateYVelocity()
        {
            var yVelocity = _rigidbody.velocity.y;
            if (IsJumpPressing)
            {
                _isJumping = true;

                var isFalling = yVelocity <= 0.5f;
                if (isFalling) _isJumping = false;

                yVelocity = isFalling ? CalculateJumpVelocity(yVelocity) : yVelocity;
            }
            else if (yVelocity > 0 && _isJumping)
            {
                yVelocity /= 2f;
            }

            return yVelocity;
        }

        private float CalculateJumpVelocity(float yVelocity)
        {
            if (_isGrounded && !JumpButtonWasPressed)
            {
                yVelocity = _jumpForce;
                JumpButtonWasPressed = true;
            }

            return yVelocity;
        }


        private float CalculateXVelocity()
        {
            _animator.SetBool(IS_RUNNING, Direction != 0);
            return Direction * _speed;
        }

        private void UpdateSpriteDirection()
        {
            if (_rigidbody.velocity.x < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                _sanityBarCanvasTransform.transform.localScale = new Vector3(-1, 1, 1);
            }
            else if (_rigidbody.velocity.x > 0)
            {
                transform.localScale = Vector3.one;
                _sanityBarCanvasTransform.transform.localScale = Vector3.one;
            }
        }
    }
}