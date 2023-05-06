using System;
using Components.Interactions;
using Components.Movement;
using Model;
using Pause;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Controls.Inputs
{
    [RequireComponent(typeof(FireflyMovementComponent))]
    [RequireComponent(typeof(PlayerInteractComponent))]
    public class FireflyInputReader : MonoBehaviour
    {
        private FireflyMovementComponent _fireflyMovementComponent;
        private PlayerInteractComponent _playerInteractComponent;
        private PauseManager _pauseManager;
        
        private void Awake()
        {
            _fireflyMovementComponent = GetComponent<FireflyMovementComponent>();
            _playerInteractComponent = GetComponent<PlayerInteractComponent>();
        }

        private void Start()
        {
            _pauseManager = GameSession.Instance.PauseManager;
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            _fireflyMovementComponent.Direction = context.ReadValue<Vector2>();
        }

        public void OnInteract(InputAction.CallbackContext context)
        {
            if (context.started) _playerInteractComponent.Interact();
        }

        public void OnPause(InputAction.CallbackContext context)
        {
            if (context.started) 
                _pauseManager.SetPaused(!_pauseManager.IsPaused);
        }
    }
}