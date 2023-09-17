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
            Cursor.visible = isPaused;
            if (GameSession.Instance.IsCutscene) return;
            gameObject.SetActive(isPaused);
            _globalVolume.enabled = isPaused;
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