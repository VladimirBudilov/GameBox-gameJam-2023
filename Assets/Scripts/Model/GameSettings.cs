﻿using PersistantData;
using UnityEngine;

namespace Model
{
    [CreateAssetMenu(menuName = "Data/GameSettings", fileName = "GameSettings")]
    public class GameSettings : ScriptableObject
    {
        [SerializeField] private FloatPersistentProperty _music;
        [SerializeField] private FloatPersistentProperty _sfx;

        public FloatPersistentProperty Music => _music;
        public FloatPersistentProperty Sfx => _sfx;

        private static GameSettings _instance;
        public static GameSettings Instance => _instance == null ? LoadGameSettings() : _instance;

        private static GameSettings LoadGameSettings()
        {
            return _instance = Resources.Load<GameSettings>("GameSettings");
        }

        private void OnEnable()
        {
            _music = new FloatPersistentProperty(1f, SoundSettings.Music.ToString());
            _sfx = new FloatPersistentProperty(1f, SoundSettings.Sfx.ToString());
        }

        private void OnValidate()
        {
            _music.Validate();
            _sfx.Validate();
        }

    }

    public enum SoundSettings 
    {
        Music,
        Sfx
    }
}