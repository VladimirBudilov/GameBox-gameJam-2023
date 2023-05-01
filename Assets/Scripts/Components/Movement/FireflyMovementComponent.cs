using UnityEngine;

namespace Components.Movement
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class FireflyMovementComponent : MonoBehaviour
    {
        [Header("Settings fields")]
        [SerializeField] private float _chaseSpeed;
        [SerializeField] private float _speed;
        [SerializeField] private int _flyToTargetDirectionDistance = 4;
        
        [Space][Header("System fields")]
        [SerializeField] private Transform _targetDirectionTransform;
        [SerializeField] private Transform _flyToPositionWhileIdle;

        private Rigidbody2D _rigidbody;
        public Vector2 Direction { get; set; }

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        public void FixedUpdate()
        {
            CalculateVelocity();
            
            CalculateTargetDirectionHelper();

            if (Direction.x == 0 && Direction.y == 0) ChasePlayer();
        }

        private void CalculateVelocity()
        {
            _rigidbody.velocity = Direction * _speed;
        }

        private void CalculateTargetDirectionHelper()
        {
            _targetDirectionTransform.localPosition = Direction * _flyToTargetDirectionDistance;
        }

        private void ChasePlayer()
        {
            var directionToFly = _flyToPositionWhileIdle.position - transform.position;
            if (directionToFly.magnitude < 1f) return;
            _rigidbody.velocity = directionToFly.normalized * _chaseSpeed;
        }
    }
}