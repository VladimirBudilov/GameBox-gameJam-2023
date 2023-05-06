using System;
using Model;
using Pause;
using UnityEngine;

namespace Utils
{
    [Serializable]
    public class Timer : IPauseHandler
    {
        [SerializeField] private float _value;
        private float _timeUp;
        private float _timeOnPause;
        private bool IsPaused => GameSession.Instance == null ? false : GameSession.Instance.PauseManager.IsPaused;
        public float Value
        {
            get => _value;
            set => _value = value;
        }

        public void Reset()
        {
            _timeUp = Time.time + _value;
        }

        public void EarlyComplete()
        {
            _timeUp -= _value;
        }

        public float RemainingTime => Mathf.Max(_timeUp - Time.time, 0f);

        public bool IsReady => !IsPaused && _timeUp <= Time.time;
        
        public void SetPaused(bool isPaused)
        {
            if (isPaused)
            {
                _timeOnPause = Time.time;
            }
            else
            {
                _timeOnPause = Time.time - _timeOnPause;
                _timeUp += _timeOnPause;
            }
        }
    }
}