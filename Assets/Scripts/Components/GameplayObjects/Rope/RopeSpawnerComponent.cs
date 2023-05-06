using UnityEngine;

namespace Components.GameplayObjects.Rope
{
    public class RopeSpawnerComponent : MonoBehaviour
    {
        [SerializeField] private RopeComponent _ropePrefab;
        [SerializeField] private Transform _ropeSpawnPosition;
        [SerializeField] private bool _isRightCliff;
        [SerializeField] private int _ropeDistanceInLinks;
        [SerializeField] private int _startRopeForce;
        private bool _isSpawned;

        [ContextMenu("Spawn")]
        public void SpawnRope()
        {
            if (_isSpawned) return;
            var rope = Instantiate(_ropePrefab).GetComponent<RopeComponent>();
            rope.transform.position = _ropeSpawnPosition.position;
            rope.GenerateRope(_isRightCliff, _ropeDistanceInLinks, _startRopeForce);
            _isSpawned = true;
        }
    }
}
