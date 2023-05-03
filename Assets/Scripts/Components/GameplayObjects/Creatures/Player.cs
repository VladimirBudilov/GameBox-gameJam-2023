using System;
using Components.Interactions;
using Components.Movement;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Components.GameplayObjects.Creatures
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private PlayerMovementComponent _movementComponent;
        [SerializeField] private PlayerRopeMovementComponent _ropeMovementComponent;
        [SerializeField] private PlayerInteractComponent _interactComponent;
        [SerializeField] private PlayerInput _input;
        [SerializeField] private Transform _fireflyTransformToFly;

        public PlayerMovementComponent MovementComponent => _movementComponent;
        public PlayerInteractComponent InteractComponent => _interactComponent;
        public PlayerRopeMovementComponent RopeMovementComponent => _ropeMovementComponent;
        public Transform FireflyTransformToFly => _fireflyTransformToFly;

        private void Awake()
        {
            _input.ActivateInput();
        }

        public void SetRopeMovement()
        {
            _input.currentActionMap = _input.actions.FindActionMap("Rope actions");

        }

        public void SetGroundMovement()
        {
            _input.currentActionMap = _input.actions.FindActionMap("Ground actions");
        }
    }
}