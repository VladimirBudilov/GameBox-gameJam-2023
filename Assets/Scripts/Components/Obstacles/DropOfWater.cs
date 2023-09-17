using Components.GameplayObjects.Creatures;
using Model;
using Pause;
using UnityEngine;

namespace Components.Obstacles
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(AudioSource))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class DropOfWater : MonoBehaviour, IPauseHandler
    {
        [SerializeField] float _damage;
        private Rigidbody2D _rigidbody;
        private AudioSource _audio;
        private SpriteRenderer _sprite;
        private bool _isDestroy;
        private PauseManager Pause => GameSession.Instance.PauseManager;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _audio = GetComponent<AudioSource>();
            _sprite = GetComponent<SpriteRenderer>();
        }

        public void Destroy()
        {
            _sprite.enabled = false;
            _isDestroy = true;
        }

        public void DealDamage(GameObject target)
        {
            if (target.TryGetComponent(out FireflyLightComponent light))
            {
                light.Damage(_damage);
            }
        }

        private void Update()
        {
            if (!_isDestroy || _audio.isPlaying) return;

            Destroy(gameObject);
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