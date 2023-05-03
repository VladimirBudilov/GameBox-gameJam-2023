using System;
using UnityEngine;

namespace Components.GameplayObjects.Creatures
{
    public class PlayerRopeMovementComponent : MonoBehaviour
    {
        [SerializeField] private Joint2D _playerJoint;

        public Vector2 Direction { get; set; }

        public void OnStartClimb(Rigidbody2D startRopeLink)
        {
            _playerJoint.gameObject.SetActive(true);
            _playerJoint.connectedBody = startRopeLink;
        }

        public void OnStopClimb()
        {
            _playerJoint.gameObject.SetActive(false);
        }

        private void FixedUpdate()
        {
            
        }
    }
}