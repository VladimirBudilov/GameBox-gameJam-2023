using Components.Audio;
using Components.GameplayObjects.Creatures;
using UnityEngine;

namespace Components.Obstacles
{
    public class DropOfWater : MonoBehaviour
    {
        [SerializeField] float _damage;
        [SerializeField] private AudioSource _source;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private PlaySoundComponent _playSoundComponent;
        private bool _isDestroy;
        
        public void Destroy()
        {
            _playSoundComponent.PlayRandomSound();
            _spriteRenderer.enabled = false;
            _isDestroy = true;
        }

        private void Update()
        {
            if (!_isDestroy || _source.isPlaying) return;

            Destroy(gameObject);
        }

        public void DealDamage(GameObject target)
        {
            if (target.TryGetComponent(out FireflyLightComponent lightComponent))
            {
                lightComponent.Damage(_damage);
            }
        }
    }
}
