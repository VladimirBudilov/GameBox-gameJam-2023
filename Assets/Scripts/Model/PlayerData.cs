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

        public PlayerData Clone()
        {
            var json = JsonUtility.ToJson(this);
            return JsonUtility.FromJson<PlayerData>(json);
        }
    }
}