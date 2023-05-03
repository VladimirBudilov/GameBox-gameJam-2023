using System;
using PersistantData;
using UnityEngine;

namespace Model
{
    [Serializable]
    public class PlayerData
    {
        public FloatProperty Sanity = new FloatProperty();
        public FloatProperty FireflyLight = new FloatProperty();
        private float _maxSanity;
        private float _maxFireflyLight;

        public float MaxSanity
        {
            get => _maxSanity;
            set
            {
                if (_maxSanity == 0)
                    _maxSanity = value;
            }
        }

        public float MaxFireflyLight
        {
            get => _maxFireflyLight;
            set
            {
                if (_maxFireflyLight == 0)
                    _maxFireflyLight = value;
            }
        }

        public PlayerData Clone()
        {
            var json = JsonUtility.ToJson(this);
            return JsonUtility.FromJson<PlayerData>(json);
        }
    }
}