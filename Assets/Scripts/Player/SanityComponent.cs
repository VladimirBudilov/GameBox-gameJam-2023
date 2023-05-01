using System;
using Model;
using PersistantData;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace Player
{
    public class SanityComponent : MonoBehaviour
    {
        [SerializeField] private float _maxSanity;
        private FloatProperty _sanity;
        private Timer _timer = new Timer();
        
        public FloatProperty Sanity { get => _sanity; set => _sanity = value; }
        private void Start()
        {
            Sanity = GameSession.Instance.PlayerData.Sanity;
            Sanity.Value = _maxSanity;
            GameSession.Instance.PlayerData.MaxSanity = _maxSanity;
            _timer.Value = _maxSanity;
            _timer.Reset();
        }

        private void FixedUpdate()
        {
            Sanity.Value = _timer.RemainingTime();
        }

        public void StopMentalDamage()
        {
            _timer.Suspend();
        }

        public void ContinueMentalDamage()
        {
            _timer.Continue();
        }
    }
}