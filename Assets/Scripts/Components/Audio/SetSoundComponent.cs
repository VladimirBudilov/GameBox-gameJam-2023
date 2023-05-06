using UnityEngine;

namespace Components.Audio
{
    public class SetSoundComponent : MonoBehaviour
    {
        [SerializeField] private string _soundId;

        public void PlaySound(GameObject target)
        {
            target.GetComponent<PlaySoundComponent>().Play(_soundId);
        }
    }
}
