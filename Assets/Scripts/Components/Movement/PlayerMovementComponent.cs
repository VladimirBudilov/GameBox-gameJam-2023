using Components.Audio;
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
        [SerializeField] private PlaySoundComponent _playSoundComponent;

        [SerializeField] private float _speed;
        [SerializeField] private float _jumpForce;
        [SerializeField] private float _deathHigh;

        [Space] [Header("Checkers")] [SerializeField]
        private DeathEvent _deathEvent;

        [SerializeField] private LayerCheck _groundCheck;

        [Space] [Header("UI")] [SerializeField]
        private Transform _sanityBarCanvasTransform;

        private Rigidbody2D _rigidbody;
        private bool _isJumping;
        private bool _isGrounded;
        private bool _isDied;

        private static readonly int IS_RUNNING = Animator.StringToHash("is-running");
        private static readonly int JUMP = Animator.StringToHash("jump");
        private static readonly int IS_FALLING = Animator.StringToHash("is-falling");
        private static readonly int IS_GROUNDED = Animator.StringToHash("is-ground");

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
                _animator.enabled = false;
                _deathEvent?.Invoke("fall");
            }
            
            _isGrounded = _groundCheck.IsTouchingLayer;
        }

        private void FixedUpdate()
        {
            if (!IsActive || _isDied) return;
            var velocity = CalculateVelocity();
            _rigidbody.velocity = velocity;
            _animator.SetBool(IS_FALLING, _rigidbody.velocity.y < 0);
            _animator.SetBool(IS_GROUNDED, _isGrounded);
            
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
                _animator.SetTrigger(JUMP);
                PlayJumpSound();
            }

            return yVelocity;
        }

        private void PlayJumpSound()
        {
            if (Random.Range(0,4) == 0)
                switch (Random.Range(0,2))
                {
                    case 0:
                    {
                        _playSoundComponent.Play("jump-1");
                        break;
                    }
                    case 1:
                    {
                        _playSoundComponent.Play("jump-2");
                        break;
                    }
                }
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