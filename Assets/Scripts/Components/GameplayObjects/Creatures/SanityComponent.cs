using Components.ColliderBased;
using Model;
using Pause;
using PersistantData;
using Unity.Mathematics;
using UnityEngine;
using Utils;

namespace Components.GameplayObjects.Creatures
{
    public class SanityComponent : MonoBehaviour
    {
        [Header("SanityComponent Stats")]
        [SerializeField] private Timer _sanityTickLoseTimer;
        [SerializeField] private float _sanityLoseByTick;
        [SerializeField] private Timer _sanityTickRegenTimer;
        [SerializeField] private float _sanityRegenByTick;
        [Space][Header("SanityComponent Checks")]
        [SerializeField] private LayerCheck _saveZoneCheck;
        [SerializeField] private LayerCheck _lightCheck;
        [Space][Header("SanityComponent amount stats")]
        [SerializeField] private float _maxSanity;
        [SerializeField] private DeathEvent _deathEvent;
        
        private FloatProperty _sanity;

        private PauseManager Pause => GameSession.Instance.PauseManager;

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
            Pause.Register(_sanityTickLoseTimer);
            Pause.Register(_sanityTickRegenTimer);
            _sanity.OnChanged += OnSanityChanged;
        }

        private void OnSanityChanged(float newValue, float __)
        {
            if (newValue == 0)
            {
                _deathEvent?.Invoke("sanity");
            }
        }
        
        private void OnDestroy()
        {
            _sanity.OnChanged -= OnSanityChanged;
            Pause.UnRegister(_sanityTickLoseTimer);
            Pause.UnRegister(_sanityTickRegenTimer);
        }

        private void Update()
        {
            if (!_lightCheck.IsTouchingLayer && !_saveZoneCheck.IsTouchingLayer && _sanityTickLoseTimer.IsReady)
            {
                var newSanityValue = _sanity.Value - _sanityLoseByTick;
                Sanity.Value = math.max(0, newSanityValue);
                _sanityTickLoseTimer.Reset();
            }

            if (_saveZoneCheck.IsTouchingLayer && _sanityTickRegenTimer.IsReady)
            {
                var newSanityValue = _sanity.Value + _sanityRegenByTick;
                _sanity.Value = Mathf.Min(newSanityValue, _maxSanity);
                _sanityTickRegenTimer.Reset();
            }
        }
    }
}