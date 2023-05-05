using UnityEngine;

namespace Components.Audio
{
    public class PlaySoundComponent : MonoBehaviour
    {
        [SerializeField] private AudioSource _source;
        [SerializeField] private AudioData[] _sounds;

        public void Play(string id)
        {
            foreach (var audioData in _sounds)
            {
                if (audioData.Id != id) continue;
                _source.PlayOneShot(audioData.Clip);
                break;
            }
        }
    }
}