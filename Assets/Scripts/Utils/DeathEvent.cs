using System;
using UnityEngine.Events;

namespace Utils
{
    [Serializable]
    public class DeathEvent : UnityEvent<string>
    {
    }
}