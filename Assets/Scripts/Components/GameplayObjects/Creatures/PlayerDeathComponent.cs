using Model;
using UnityEngine;

namespace Components.GameplayObjects.Creatures
{
    public class PlayerDeathComponent : MonoBehaviour
    {
        public void Death(string deathId)
        {
            GameSession.Instance.ShowDeath(deathId);
        }
    }
}