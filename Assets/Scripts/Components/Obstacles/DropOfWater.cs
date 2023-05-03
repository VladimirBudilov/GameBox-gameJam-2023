using Player;
using UnityEngine;

namespace Obstacles
{
    public class DropOfWater : MonoBehaviour
    {
        [SerializeField] float _damage;
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
    }
}
