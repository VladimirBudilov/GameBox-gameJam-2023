using UnityEngine;

namespace Model
{
    public class GameSession : MonoBehaviour
    {
        [SerializeField] private PlayerData _playerData;

        public PlayerData PlayerData => _playerData;
        
        public static GameSession Instance;
        
        private void Awake()
        {
            Instance ??= this;
        }
    }
}