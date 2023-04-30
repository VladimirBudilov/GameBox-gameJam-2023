using UnityEngine;

namespace Controllers
{
    public class PersonMovements : MonoBehaviour
    {
        private Rigidbody2D rb;
        [SerializeField] private float _speed;
        [SerializeField] private float _jumpForce;
        public float Direction { get; set; }
        public bool IsJumpPressing { get; set; }
        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            var velocity = CalculateVelocity();
            rb.velocity = velocity;
        }

        private Vector2 CalculateVelocity()
        {
            var xVelocity = CalculateXVelocity();
            var yVelocity = CalculateYVelocity();
            return new Vector2(xVelocity, yVelocity);
        }

        private float CalculateYVelocity()
        {
            if (!IsJumpPressing) return rb.velocity.y;
            if (rb.velocity.y != 0)
                return rb.velocity.y;
            rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            IsJumpPressing = false;
            return rb.velocity.y;
        }

        private float CalculateXVelocity()
        {
            return Direction * _speed;
        }
    }
}