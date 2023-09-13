using Components.GameplayObjects.Creatures;
using Pause;
using UI.Menus;
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
        private DeathScreenComponent _deathScreen;
        private Vector3 _lastCheckPointPosition;
        public PlayerData PlayerData => _playerData;
        public Player Player { get; private set; }
        public PauseManager PauseManager { get; private set; }
        
        public static GameSession Instance;
        public bool IsCutscene { get; set; }

        private void Awake()
        {
            var existSession = GetExistSession();
            if (existSession != null)
            {
                IsCutscene = false;
                existSession.StartSession();
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
                SetSpawnPosition(_spawnPosition);
                StartSession();
                DontDestroyOnLoad(this);
            }
        }

        private void StartSession()
        {
            LoadUI();
            InitModels();
            SpawnPlayer();
        }

        private void LoadUI()
        {
            _deathScreen = FindObjectOfType<DeathScreenComponent>();
            _deathScreen.gameObject.SetActive(false);
        }

        private GameSession GetExistSession()
        {
            var sessions = FindObjectsOfType<GameSession>();
            foreach (var session in sessions)
            {
                if (session != this) return session;
            }

            return null;
        }

        private void InitModels()
        {
            PauseManager = new PauseManager();
        }

        private void SpawnPlayer()
        {
            Player = Instantiate(_playerPrefab.gameObject, _lastCheckPointPosition, Quaternion.identity).GetComponent<Player>();
            Player.SetGroundMovement();
            Instantiate(_fireflyPrefab, Player.FireflyTransformToFly.position, quaternion.identity);
        }

        public void ShowDeath(string id)
        {
            IsCutscene = true;
            Cursor.visible = true;
            _deathScreen.gameObject.SetActive(true);
            PauseManager.SetPaused(true);
            _deathScreen.Death(id);
        }

        public void SetSpawnPosition(Transform spawnPosition)
        {
            _lastCheckPointPosition = new Vector3(spawnPosition.position.x, spawnPosition.position.y, spawnPosition.position.z);
        }
    }
}