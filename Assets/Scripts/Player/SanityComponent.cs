using Components.ColliderBased;
using Model;
using PersistantData;
using Unity.Mathematics;
using UnityEngine;

namespace Player
{
    public class SanityComponent : MonoBehaviour
    {
        [SerializeField] private float _maxSanity;
        [SerializeField] private Timer _sanityTickLoseTimer;
        [SerializeField] private float _sanityLoseByTick;
        [SerializeField] private LayerCheck _darknessCheck;
        [SerializeField] private LayerCheck _lightCheck;
        private FloatProperty _sanity;

        public FloatProperty Sanity
        {
            get => _sanity;
            set => _sanity = value;
        }

        private void Start()
        {
            Sanity = GameSession.Instance.PlayerData.Sanity;
            Sanity.Value = _maxSanity;
            GameSession.Instance.PlayerData.MaxSanity = _maxSanity;
        }

        private void Update()
        {
            if (_darknessCheck.IsTouchingLayer && !_lightCheck.IsTouchingLayer && _sanityTickLoseTimer.IsReady)
            {
                var newSanityValue = _sanity.Value - _sanityLoseByTick;
                Sanity.Value = math.max(0, newSanityValue);
                _sanityTickLoseTimer.Reset();
            }

            if (_lightCheck.IsTouchingLayer && _sanityTickLoseTimer.IsReady)
            {
                var newSanityValue = _sanity.Value + _sanityLoseByTick;
                _sanity.Value = Mathf.Min(newSanityValue, _maxSanity);
                _sanityTickLoseTimer.Reset();
            }
        }
    }
}