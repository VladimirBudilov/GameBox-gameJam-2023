using Model;
using UI.Widgets;
using UnityEngine;

namespace UI.Menus
{
    public class SettingsMenu : MonoBehaviour
    {
        [SerializeField] private AudioSettingsWidget _music;
        [SerializeField] private AudioSettingsWidget _sfx;
        protected void Start()
        {
            _music.SetModel(GameSettings.Instance.Music);
            _sfx.SetModel(GameSettings.Instance.Sfx);
        }
    }
}