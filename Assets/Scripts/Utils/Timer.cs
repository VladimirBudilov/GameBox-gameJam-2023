using System;
using UnityEngine;

namespace Utils
{
    [Serializable]
    public class Timer
    {
        [SerializeField] private float _value;
        private float _timeUp;
        private float _timeSuspend;
        private bool _timeIsSuspended = false;

        public float Value
        {
            get => _value;
            set => _value = value;
        }

        public void Reset()
        {
            _timeUp = Time.time + _value;
        }

        public void Suspend()
        {
            _timeSuspend = Mathf.Max(_timeUp - Time.time, 0f);
            _timeIsSuspended = true;
        }

        public void Continue()
        {
            _timeUp = Time.time + _timeSuspend;
            _timeIsSuspended = false;
        }

        public void EarlyComplete()
        {
            _timeUp -= _value;
        }

        public float RemainingTime()
        {
            if (_timeIsSuspended) return _timeSuspend;
            return Mathf.Max(_timeUp - Time.time, 0f);
        }

        public bool IsReady()
        {
            if (_timeIsSuspended) return _timeUp <= _timeSuspend;
            return _timeUp <= Time.time;
        }

        public bool IsSuspended() => _timeIsSuspended;
    }
}