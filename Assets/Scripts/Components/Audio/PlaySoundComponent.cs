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

        public void PlayRandomSound()
        {
            var randomClip = Random.Range(0, _sounds.Length);

            _source.PlayOneShot(_sounds[randomClip].Clip);
        }
    }
}