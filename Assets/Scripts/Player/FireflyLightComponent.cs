using Model;
using PersistantData;
using UnityEngine;
using Utils;

namespace Player
{
    public class FireflyLightComponent : MonoBehaviour
    {
        [SerializeField] private float _maxFireflyLight;
        [SerializeField] private Timer _fireflyLoseLightTimer;
        private FloatProperty _fireflyLight;

        public FloatProperty FireflyLight { get => _fireflyLight; set => _fireflyLight = value; }
        private void Start()
        {
            FireflyLight = GameSession.Instance.PlayerData.FireflyLight;
            FireflyLight.Value = _maxFireflyLight;
            GameSession.Instance.PlayerData.MaxSanity = _maxFireflyLight;
        }
    }
}
