﻿using System;
using Model;
using PersistantData;
using UnityEngine;

namespace Components.Audio
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioSettingComponent : MonoBehaviour
    {
        [SerializeField] SoundSettings _mode;
        private AudioSource _source;
        private FloatPersistentProperty _model;

        public AudioSource Source => _source;

        private void Awake()
        {
            _source = GetComponent<AudioSource>();
            _model = FindProperty();
            _model.OnChanged += OnSoundSettingsChange;

            OnSoundSettingsChange(_model.Value, _model.Value);
        }

        private void OnSoundSettingsChange(float newValue, float oldValue)
        {
            _source.volume = newValue;
        }

        private FloatPersistentProperty FindProperty()
        {
            switch (_mode)
            {
                case SoundSettings.Music: return GameSettings.Instance.Music;
                case SoundSettings.Sfx: return GameSettings.Instance.Sfx;
            }

            throw new ArgumentException("Undefiend argument");
        }

        private void OnDestroy()
        {
            _model.OnChanged -= OnSoundSettingsChange;
        }
    }
}