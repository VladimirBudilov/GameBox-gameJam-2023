using UnityEngine;

namespace Components.Movement
{
    public class PlayerMovementComponent : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _jumpForce;
        private Rigidbody2D _rigidbody;

        public float Direction { get; set; }
        public bool IsJumpPressing { get; set; }
        
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
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
            if (!IsJumpPressing) return _rigidbody.velocity.y;
            if (Mathf.Abs(_rigidbody.velocity.y) > 0.01f)
                return _rigidbody.velocity.y;
            _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            IsJumpPressing = false;
            return _rigidbody.velocity.y;
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