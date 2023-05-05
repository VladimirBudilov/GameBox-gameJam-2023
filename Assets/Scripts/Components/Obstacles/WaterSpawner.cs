using Model;
using Pause;
using UnityEngine;
using Utils;

namespace Components.Obstacles
{
    public class WaterSpawner : MonoBehaviour
    {
        [SerializeField] private Timer _waterSpawnerTimer;
        [SerializeField] private GameObject _water;
        private PauseManager Pause => GameSession.Instance.PauseManager;
        
        private void Start()
        {
            Pause.Register(_waterSpawnerTimer);
        }

        private void OnDisable()
        {
            Pause.UnRegister(_waterSpawnerTimer);
        }

        private void Update()
        {
            if (_waterSpawnerTimer.IsReady)
            {
                var drop = Instantiate(_water, transform);
                drop.transform.parent = gameObject.transform;
                _waterSpawnerTimer.Reset();
            }
        }
    }
}
