using Components.Interactions;
using Components.Movement;
using Model;
using Pause;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Components.GameplayObjects.Creatures
{
    [RequireComponent(typeof(PlayerMovementComponent))]
    [RequireComponent(typeof(PlayerRopeMovementComponent))]
    [RequireComponent(typeof(PlayerInteractComponent))]
    [RequireComponent(typeof(PlayerInput))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class Player : MonoBehaviour, IPauseHandler
    {
        [SerializeField] private Transform _fireflyTransformToFly;
        private PlayerMovementComponent _movementComponent;
        private PlayerRopeMovementComponent _ropeMovementComponent;
        private PlayerInteractComponent _interactComponent;
        private PlayerInput _input;
        private Rigidbody2D _rigidbody;

        public PlayerMovementComponent MovementComponent => _movementComponent;
        public PlayerInteractComponent InteractComponent => _interactComponent;
        public PlayerRopeMovementComponent RopeMovementComponent => _ropeMovementComponent;
        public Transform FireflyTransformToFly => _fireflyTransformToFly;
        private PauseManager Pause => GameSession.Instance.PauseManager;

        private void Awake()
        {
            _input = GetComponent<PlayerInput>();
            _movementComponent = GetComponent<PlayerMovementComponent>();
            _ropeMovementComponent = GetComponent<PlayerRopeMovementComponent>();
            _interactComponent = GetComponent<PlayerInteractComponent>();
            _rigidbody = GetComponent<Rigidbody2D>();
            _input.ActivateInput();
        }

        private void Start()
        {
            Pause.Register(this);
            GameSession.Instance.Player.SetGroundMovement();
        }

        public void SetRopeMovement()
        {
            _input.currentActionMap = _input.actions.FindActionMap("Rope actions");
            _movementComponent.IsActive = false;
            _ropeMovementComponent.IsActive = true;
        }

        public void SetGroundMovement()
        {
            _input.currentActionMap = _input.actions.FindActionMap("Ground actions");
            _movementComponent.IsActive = true;
            _ropeMovementComponent.IsActive = false;
        }

        public void SetPaused(bool isPaused)
        {
            if (isPaused) _input.DeactivateInput();
            else _input.ActivateInput();
            _rigidbody.simulated = !isPaused;
        }

        private void OnDestroy()
        {
            Pause.UnRegister(this);
        }
    }
}