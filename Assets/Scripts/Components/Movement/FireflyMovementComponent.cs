using System;
using Model;
using Pause;
using UnityEngine;

namespace Components.Movement
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class FireflyMovementComponent : MonoBehaviour, IPauseHandler
    {
        [Header("Settings fields")] [SerializeField]
        private float _speed;

        [SerializeField] private int _flyToTargetDirectionDistance = 4;

        [Space] [Header("System fields")] [SerializeField]
        private Transform _targetDirectionTransform;

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
        }

        public void FixedUpdate()
        {
            CalculateVelocity();

            CalculateTargetDirectionHelper();
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