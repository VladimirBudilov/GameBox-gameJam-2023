using Model;
using Pause;
using UnityEngine;
using UnityEngine.Rendering;

namespace UI.Menus
{
    public class InGameSettingsMenu : SettingsMenu, IPauseHandler
    {
        [SerializeField] private Volume _globalVolume;
        private PauseManager PauseManager => GameSession.Instance.PauseManager;
        private void Start()
        {
            PauseManager.Register(this);
            gameObject.SetActive(false);
            Cursor.visible = false;
        }

        public void SetPaused(bool isPaused)
        {
            gameObject.SetActive(isPaused);
            _globalVolume.enabled = isPaused;
            Cursor.visible = isPaused;
        }
        
        private void OnDestroy()
        {
            PauseManager.UnRegister(this);
        }

        public void Exit()
        {
            Application.Quit();
        }

        public void UnPause()
        {
            GameSession.Instance.PauseManager.SetPaused(false);
        }
    }
}