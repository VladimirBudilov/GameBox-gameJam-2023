using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Utils;

namespace Components.Interactions
{
    public class InteractWithFillComponent : MonoBehaviour
    {
        [SerializeField] private Timer _fillTickTimer;
        [SerializeField] private float _fillAmountWithTick;
        [SerializeField] private Image _fillImage;
        [SerializeField] private UnityEvent _action;
        private bool _isFilling;
        private bool _isFilled;
        
        private void Awake()
        {
            _fillImage.fillAmount = 0;
        }

        public void StartFill()
        {
            _isFilling = true;
        }

        public void StopFill()
        {
            _isFilling = false;
            _fillImage.fillAmount = 0;
        }

        private void Update()
        {
            if (_isFilled || !_isFilling || !_fillTickTimer.IsReady) return;

            _fillImage.fillAmount += _fillAmountWithTick;
            _fillTickTimer.Reset();
            if (_fillImage.fillAmount >= 1)
            {
                _isFilled = true;
                _action?.Invoke();
            }
        }
    }
}