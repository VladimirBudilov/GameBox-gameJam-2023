using Model;
using Pause;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Utils;

namespace Components.Interactions
{
    public class InteractWithFillComponent : MonoBehaviour, IPauseHandler
    {
        [SerializeField] private Timer _fillTickTimer;
        [SerializeField] private float _fillAmountWithTick;
        [SerializeField] private Image _fillImage;
        [SerializeField] private UnityEvent _action;
        [SerializeField] private AudioSource _source;
        private bool _isFilling;
        private bool _isFilled;
        private float _pauseTime;
        
        private void Awake()
        {
            _fillImage.fillAmount = 0;
        }

        private void Start()
        {
            GameSession.Instance.PauseManager.Register(this);
        }

        private void OnDestroy()
        {
            GameSession.Instance.PauseManager.UnRegister(this);
        }

        public void StartFill()
        {
            if (_isFilled) return;
            _isFilling = true;
            _source.Play();
        }

        public void StopFill()
        {
            if (_isFilled) return;
            _isFilling = false;
            _source.Stop();
            _fillImage.fillAmount = 0;
        }

        private void Update()
        {
            if (_isFilled || !_isFilling || !_fillTickTimer.IsReady || GameSession.Instance.PauseManager.IsPaused) return;

            _fillImage.fillAmount += _fillAmountWithTick;
            _fillTickTimer.Reset();
            if (_fillImage.fillAmount >= 1)
            {
                _isFilled = true;
                _action?.Invoke();
                _source.mute = true;
            }
        }

        public void SetPaused(bool isPaused)
        {
            if (isPaused) _pauseTime = _source.time;
            else
            {
                _source.Play();
                _source.time = _pauseTime;
            }
        }
    }
}