using Model;
using UnityEngine;

namespace Components.Audio
{
    [RequireComponent(typeof(AudioSource))]
    public class AmbientChanger : MonoBehaviour
    {
        [SerializeField] private AudioData[] _clipsData;
        private AudioSource _source;
        private AudioClip _queuedClip;
        private bool _isNewClipInQueue;
        private bool IsPaused => GameSession.Instance.PauseManager.IsPaused;


        private void Awake()
        {
            _source = GetComponent<AudioSource>();
        }

        public void ChangeClip(string id)
        {
            _queuedClip = null;
            foreach (var clipData in _clipsData)
            {
                if (clipData.Id != id) continue;
                _queuedClip = clipData.Clip;
                break;
            }

            if (_queuedClip == null)
            {
                Debug.LogError($"No clip with {id} found!");
            }
            else
            {
                _source.loop = false;
                _isNewClipInQueue = true;
            }
        }

        private void Update()
        {
            if (!_isNewClipInQueue || _source.isPlaying || IsPaused) return;

            _source.clip = _queuedClip;
            _source.loop = true;
            _source.Play();
            _isNewClipInQueue = false;
        }
    }
}
