using Components.GameplayObjects.Creatures;
using Model;
using Pause;
using UnityEngine;
using UnityEngine.Events;
using Utils;

namespace Components.Movement
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class FireflyMovementComponent : MonoBehaviour, IPauseHandler
    {
        [Header("Settings fields")] [SerializeField]
        private float _speed;

        [SerializeField] private float _maxDistance;
        [SerializeField] private int _flyToTargetDirectionDistance = 4;
        [SerializeField] private UnityEvent _callingEvent;
        [SerializeField] private Timer _idleTimer;

        [Space] [Header("System fields")] [SerializeField]
        private Transform _targetDirectionTransform;

        private Transform _playerTransform;
        public Vector2 Direction { get; set; }
        private Rigidbody2D _rigidbody;
        private PauseManager Pause => GameSession.Instance.PauseManager;


        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            Pause.Register(this);
            _playerTransform = FindObjectOfType<Player>().transform;
        }

        public void FixedUpdate()
        {
            CalculateVelocity();
            CheckedDistance();
            CalculateTargetDirectionHelper();
        }

        private void CheckedDistance()
        {
            var currentDistance =
                Vector2.Distance(transform.position, _playerTransform.position);
            if ((currentDistance > _maxDistance) && _idleTimer.IsReady)
            {
                _callingEvent.Invoke();
                _idleTimer.Reset();
            }
        }

        private void CalculateVelocity()
        {
            _rigidbody.velocity = Direction * _speed;
        }

        private void CalculateTargetDirectionHelper()
        {
            _targetDirectionTransform.localPosition = Direction * _flyToTargetDirectionDistance;
        }

        private void OnDestroy()
        {
            Pause.UnRegister(this);
        }

        public void SetPaused(bool isPaused)
        {
            _rigidbody.simulated = !isPaused;
        }
    }
}