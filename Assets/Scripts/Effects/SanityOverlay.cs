using Model;
using UnityEngine;
using UnityEngine.UI;

namespace Effects
{
    public class SanityOverlay : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private Sprite[] _sprites;
        private GameSession _gameSession;

        private void Start()
        {
            _gameSession = GameSession.Instance;
            _gameSession.PlayerData.Sanity.OnChanged += OnSanityChanged;
        }

        private void OnSanityChanged(float newValue, float _)
        {
            var maxSanity = _gameSession.PlayerData.MaxSanity;
            if (maxSanity == 0 || newValue <= 0 || newValue > maxSanity) return;
            var segmentValueAmount = maxSanity / _sprites.Length;
            var segment = Mathf.Max(_sprites.Length - (int) (newValue / segmentValueAmount) - 1, 0);
            _image.sprite = _sprites[segment];
        }

        private void OnDestroy()
        {
            _gameSession.PlayerData.Sanity.OnChanged -= OnSanityChanged;
        }
    }
}