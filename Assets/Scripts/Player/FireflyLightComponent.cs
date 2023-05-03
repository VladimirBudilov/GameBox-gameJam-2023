using Components.ColliderBased;
using Model;
using PersistantData;
using UnityEngine;
using Utils;

namespace Player
{
    public class FireflyLightComponent : MonoBehaviour
    {
        [SerializeField] private float _maxFireflyLight;
        [SerializeField] private Timer _loseLightTimer;
        [SerializeField] private float _lightLoseByTick;
        [SerializeField] private Timer _regenLightTimer;
        [SerializeField] private float _lightRegenByTick;
        [SerializeField] private LayerCheck _saveZoneMask;
        private FloatProperty _fireflyLight;

        public FloatProperty FireflyLight { get => _fireflyLight; set => _fireflyLight = value; }
        private void Start()
        {
            FireflyLight = GameSession.Instance.PlayerData.FireflyLight;
            FireflyLight.Value = _maxFireflyLight;
            GameSession.Instance.PlayerData.MaxFireflyLight = _maxFireflyLight;
        }

        private void Update()
        {
            if (!_saveZoneMask.IsTouchingLayer && _loseLightTimer.IsReady)
            {
                var newValue = _fireflyLight.Value - _lightLoseByTick;
                _fireflyLight.Value = Mathf.Max(0, newValue);
                _loseLightTimer.Reset();
            }

            if (_saveZoneMask.IsTouchingLayer && _regenLightTimer.IsReady)
            {
                var newValue = _fireflyLight.Value + _lightRegenByTick;
                _fireflyLight.Value = Mathf.Min(newValue, _maxFireflyLight);
                _regenLightTimer.Reset();
            }
        }

        public void Damage(float amount)
        {
            var newValue = FireflyLight.Value - amount;
            FireflyLight.Value = Mathf.Max(0, newValue);
        }
    }
}
