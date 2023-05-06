using Components.GameplayObjects.Creatures;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Model
{
    public class GlobalLightController : MonoBehaviour
    {
        [SerializeField] private float _maxIntensity = 0.8f;
        [SerializeField] private float _transformYMod = 100f;
        [SerializeField] private float _transformScaleMod = 100f;

        private Transform _player;
        private Light2D _globalLight;

        private void Start()
        {
            _player = FindObjectOfType<Player>().transform;
            _globalLight = GetComponent<Light2D>();
        }

        private void Update()
        {
            var position = _player.position;

            var newIntensity = (position.y + _transformYMod) / _transformScaleMod;
            var tempIntensity = Mathf.Min(newIntensity, _maxIntensity);
            _globalLight.intensity = Mathf.Max(0, tempIntensity);
        }
    }
}