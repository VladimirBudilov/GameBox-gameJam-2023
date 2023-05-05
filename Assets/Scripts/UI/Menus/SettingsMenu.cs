using Model;
using UI.Widgets;
using UnityEngine;

namespace UI.Menus
{
    public class SettingsMenu : MonoBehaviour
    {
        [SerializeField] private AudioSettingsWidget _music;
        [SerializeField] private AudioSettingsWidget _sfx;

        private void Awake()
        {
            _music.SetModel(GameSettings.Instance.Music);
            _sfx.SetModel(GameSettings.Instance.Sfx);
        }
    }
}