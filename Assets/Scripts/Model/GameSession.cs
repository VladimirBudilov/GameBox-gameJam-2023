using Components.GameplayObjects.Creatures;
using Pause;
using Unity.Mathematics;
using UnityEngine;

namespace Model
{
    public class GameSession : MonoBehaviour
    {
        [SerializeField] private PlayerData _playerData;
        [SerializeField] private GameObject _playerPrefab;
        [SerializeField] private GameObject _fireflyPrefab;
        [SerializeField] private Transform _spawnPosition;
        public PlayerData PlayerData => _playerData;
        public Player Player { get; private set; }
        public PauseManager PauseManager { get; private set; }
        
        public static GameSession Instance;

        private void Awake()
        {
            Instance ??= this;
            InitModels();
            SpawnPlayer();
        }

        private void InitModels()
        {
            PauseManager = new PauseManager();
        }

        private void SpawnPlayer()
        {
            Player = Instantiate(_playerPrefab.gameObject, _spawnPosition.position, Quaternion.identity).GetComponent<Player>();
            Player.SetGroundMovement();
            Instantiate(_fireflyPrefab, Player.FireflyTransformToFly.position, quaternion.identity);
        }
    }
}