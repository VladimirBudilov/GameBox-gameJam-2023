﻿using Components.GameplayObjects.Rope;
using Model;
using UnityEngine;
using Utils;

namespace Components.Movement
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(HingeJoint2D))]
    public class PlayerRopeMovementComponent : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private RuntimeAnimatorController _ropeController;
        [SerializeField] private RuntimeAnimatorController _groundController;
        [SerializeField] private float _jumpOffForce = 3f;
        [SerializeField] private Timer _grabTime;
        private HingeJoint2D _playerJoint;
        private Rigidbody2D _rigidbody;
        private bool _onRope;
        private bool _climbInProgress;

        public Vector2 Direction { get; set; }
        public bool IsActive { get; set; }

        private void Awake()
        {
            _playerJoint = GetComponent<HingeJoint2D>();
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        public void InteractWithRope(Rigidbody2D ropeLinkRigidbody)
        {
            if (_onRope && _grabTime.IsReady) ReleaseRope();
            else GrabRope(ropeLinkRigidbody);
        }

        private void GrabRope(Rigidbody2D ropeLinkRigidbody)
        {
            GameSession.Instance.Player.SetRopeMovement();
            _climbInProgress = false;
            _animator.runtimeAnimatorController = _ropeController;
            _playerJoint.connectedBody = ropeLinkRigidbody;
            _playerJoint.enabled = true;
            _onRope = true;
            _playerJoint.connectedAnchor = Vector2.zero;
            var isGrabSideRight = ropeLinkRigidbody.GetComponent<RopeLinkComponent>().IsGrabSideRight;
            UpdateSpriteDirection(isGrabSideRight);
            _playerJoint.anchor = new Vector2(0.15f, 0);
            _grabTime.Reset();
        }

        public void ReleaseRope()
        {
            GameSession.Instance.Player.SetGroundMovement();
            _animator.runtimeAnimatorController = _groundController;
            _playerJoint.enabled = false;
            _playerJoint.connectedBody = null;
            _onRope = false;
        }

        public void JumpOff()
        {
            ReleaseRope();
            _rigidbody.velocity += Vector2.up * _jumpOffForce;
        }

        private void FixedUpdate()
        {
            if (!_onRope && !IsActive) return;

            HorizontalMove();
            VerticalMove();
        }

        private void VerticalMove()
        {
            if (_climbInProgress || Direction.y > 0) return;
            RopeLinkComponent connection = _playerJoint.connectedBody.gameObject.GetComponent<RopeLinkComponent>();
            GameObject newSeg = null;

            if (Direction.y < 0 && connection.NextSegment != null)
            {
                newSeg = connection.NextSegment.gameObject;
                _animator.SetTrigger("ClimbDown");
            }

            if (newSeg != null)
            {
                transform.position = new Vector3(transform.position.x, newSeg.transform.position.y, 0);
                _playerJoint.connectedBody = newSeg.GetComponent<Rigidbody2D>();
                _climbInProgress = true;
            }
        }

        private void HorizontalMove()
        {
            //TODO: сделать раскачивание на веревке (а можно и не делать) :)
        }

        private void UpdateSpriteDirection(bool isRight)
        {
            transform.localScale = !isRight ? Vector3.one : new Vector3(-1, 1, 1);
        }

        public void OnClimbAnimationEnd()
        {
            _climbInProgress = false;
        }
    }
}