using PersistantData;
using UnityEngine;

namespace Model
{
    [CreateAssetMenu(menuName = "Data/GameSettings", fileName = "GameSettings")]
    public class GameSettings : ScriptableObject
    {
        [SerializeField] private FloatPersistentProperty _music;
        [SerializeField] private FloatPersistentProperty _sfx;
        [SerializeField] private FloatPersistentProperty _ambient;

        public FloatPersistentProperty Music => _music;
        public FloatPersistentProperty Sfx => _sfx;
        public FloatPersistentProperty Ambient => _ambient;

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
            _ambient = new FloatPersistentProperty(1f, SoundSettings.Ambient.ToString());
        }

        private void OnValidate()
        {
            _music.Validate();
            _sfx.Validate();
            _ambient.Validate();
        }

    }

    public enum SoundSettings 
    {
        Music,
        Sfx,
        Ambient
    }
}