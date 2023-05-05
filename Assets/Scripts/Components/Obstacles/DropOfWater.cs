using Components.GameplayObjects.Creatures;
using Model;
using Pause;
using UnityEngine;

namespace Components.Obstacles
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class DropOfWater : MonoBehaviour, IPauseHandler
    {
        [SerializeField] float _damage;
        private Rigidbody2D _rigidbody;
        private PauseManager Pause => GameSession.Instance.PauseManager;
        
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }
        
        public void DealDamage(GameObject target)
        {
            if (target.TryGetComponent(out FireflyLightComponent light))
            {
                light.Damage(_damage);
            }
        }

        private void OnEnable()
        {
            Pause.Register(this);
        }

        private void OnDestroy()
        {
            Pause.UnRegister(this);
        }

        public void SetPaused(bool isPaused)
        {
            _rigidbody.simulated = !isPaused;
        }
    }
}
