using UnityEngine;

namespace Components.Audio
{
    public class SetSoundComponent : MonoBehaviour
    {
        [SerializeField] private string _soundId;

        public void PlaySound(GameObject target)
        {
            if (target.TryGetComponent(out PlaySoundComponent playSoundComponent))
            {
                playSoundComponent.Play(_soundId);
            }
        }
    }
}
