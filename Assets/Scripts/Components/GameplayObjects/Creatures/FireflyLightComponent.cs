using Components.ColliderBased;
using Model;
using PersistantData;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using Utils;

namespace Components.GameplayObjects.Creatures
{
    [RequireComponent(typeof(CircleCollider2D))]
    public class FireflyLightComponent : MonoBehaviour
    {
        [SerializeField] private float _maxFireflyLight;
        [SerializeField] private float _maxFireflyLightModifer = 40f;
        [SerializeField] private Timer _loseLightTimer;
        [SerializeField] private float _lightLoseByTick;
        [SerializeField] private Timer _regenLightTimer;
        [SerializeField] private float _lightRegenByTick;
        [SerializeField] private LayerCheck _saveZoneMask;
        [SerializeField] private float _lightToColliderModifier;
        [SerializeField] private float _minLight= 1f;
        private FloatProperty _fireflyLight;
        [SerializeField] private CircleCollider2D _circleCollider;
        [SerializeField] private Light2D _light;

        public FloatProperty FireflyLight { get => _fireflyLight; set => _fireflyLight = value; }
        private void Start()
        {
            FireflyLight = GameSession.Instance.PlayerData.FireflyLight;
            FireflyLight.Value = _maxFireflyLight;
            GameSession.Instance.PlayerData.MaxFireflyLight = _maxFireflyLight;
            _circleCollider.radius = GetRealRadius() - _lightToColliderModifier;
            _light.pointLightOuterRadius = GetRealRadius();
        }

        private void Update()
        {
            if (!_saveZoneMask.IsTouchingLayer && _loseLightTimer.IsReady)
            {
                FireflyLoosingLight();
                SetLightAndCollider();
            }

            if (_saveZoneMask.IsTouchingLayer && _regenLightTimer.IsReady)
            {
                FireflyRegeneratingLight();
                SetLightAndCollider();
                
            }
        }

        private void SetLightAndCollider()
        {
            _light.pointLightOuterRadius = GetRealRadius();
            _circleCollider.radius = GetRealRadius() - _lightToColliderModifier;
        }

        private void FireflyRegeneratingLight()
        {
            var newValue = _fireflyLight.Value + _lightRegenByTick;
            _fireflyLight.Value = Mathf.Min(newValue, _maxFireflyLight);
            _regenLightTimer.Reset();
        }

        private void FireflyLoosingLight()
        {
            var newValue = _fireflyLight.Value - _lightLoseByTick;
            _fireflyLight.Value = Mathf.Max(_minLight, newValue);
            _loseLightTimer.Reset();
        }

        public void Damage(float amount)
        {
            var newValue = FireflyLight.Value - amount;
            FireflyLight.Value = Mathf.Max(0, newValue);
        }

        private float GetRealRadius()
        {
            return _fireflyLight.Value / _maxFireflyLightModifer;
        }
    }
}
