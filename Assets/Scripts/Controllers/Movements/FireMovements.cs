using System;
using UnityEngine;

namespace Controllers
{
    public class FireMovements : MonoBehaviour
    {
        
        [SerializeField] private DynamicJoystick variableJoystick;
        [SerializeField] private float _speed;
        public float DirectionX { get; set; }
        public float DirectionY { get; set; }
        private Rigidbody2D _rb;
        
        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }
        
        public void FixedUpdate()
        {
            var velocity = CalculateVelocity();
            _rb.velocity = velocity;
        }
        
        private Vector2 CalculateVelocity()
        {
            var xVelocity = CalculateXVelocity();
            var yVelocity = CalculateYVelocity();
            return new Vector2(xVelocity, yVelocity);
        }
        
        private float CalculateYVelocity()
        {
            DirectionY = variableJoystick.Vertical;
            return  DirectionY * _speed;
        }

        private float CalculateXVelocity()
        {
            DirectionX = variableJoystick.Horizontal;
            return DirectionX * _speed;
        }
    }
}