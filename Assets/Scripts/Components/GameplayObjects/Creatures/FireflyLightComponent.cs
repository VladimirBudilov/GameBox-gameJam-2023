using Components.ColliderBased;
using Model;
using Pause;
using PersistantData;
using UnityEngine;
using Utils;

namespace Components.GameplayObjects.Creatures
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
        private PauseManager Pause => GameSession.Instance.PauseManager;


        public FloatProperty FireflyLight { get => _fireflyLight; set => _fireflyLight = value; }
        private void Start()
        {
            FireflyLight = GameSession.Instance.PlayerData.FireflyLight;
            FireflyLight.Value = _maxFireflyLight;
            GameSession.Instance.PlayerData.MaxFireflyLight = _maxFireflyLight;
            Pause.Register(_loseLightTimer);
            Pause.Register(_regenLightTimer);
        }
        
        private void OnDestroy()
        {
            Pause.UnRegister(_loseLightTimer);
            Pause.UnRegister(_regenLightTimer);
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
