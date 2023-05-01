using Model;
using PersistantData;
using UnityEngine;
using Utils;

namespace Player
{
    public class FireflyLightComponent : MonoBehaviour
    {
        [SerializeField] private float _maxFireflyLight;
        private FloatProperty _fireflyLight;
        private Timer _timer = new Timer();
        
        public FloatProperty FireflyLight { get => _fireflyLight; set => _fireflyLight = value; }
        private void Start()
        {
            FireflyLight = GameSession.Instance.PlayerData.FireflyLight;
            FireflyLight.Value = _maxFireflyLight;
            GameSession.Instance.PlayerData.MaxSanity = _maxFireflyLight;
            _timer.Value = _maxFireflyLight;
            _timer.Reset();
        }

        private void FixedUpdate()
        {
            FireflyLight.Value = _timer.RemainingTime();
        }
    }
}
