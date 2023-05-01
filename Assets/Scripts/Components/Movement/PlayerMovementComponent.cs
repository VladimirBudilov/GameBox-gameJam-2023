using Components.ColliderBased;
using UnityEngine;

namespace Components.Movement
{
    public class PlayerMovementComponent : MonoBehaviour
    {
        [Header("Settings fields")]
        [SerializeField] private float _speed;
        [SerializeField] private float _jumpForce;
        [Space][Header("Checkers")]
        [SerializeField] private LayerCheck _groundCheck;
        private Rigidbody2D _rigidbody;
        private bool _isJumping;
        private bool _isGrounded;

        public float Direction { get; set; }
        public bool IsJumpPressing { get; set; }
        
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            _isGrounded = _groundCheck.IsTouchingLayer;
        }

        private void FixedUpdate()
        {
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

                var isFalling = yVelocity <= 0.001f;

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
            if (_isGrounded)
            {
                yVelocity = _jumpForce;
            }

            return yVelocity;
        }

        private float CalculateXVelocity()
        {
            return Direction * _speed;
        }
        
        private void UpdateSpriteDirection()
        {
            if (_rigidbody.velocity.x < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else if (_rigidbody.velocity.x > 0)
            {
                transform.localScale = Vector3.one;
            }
        }
    }
}