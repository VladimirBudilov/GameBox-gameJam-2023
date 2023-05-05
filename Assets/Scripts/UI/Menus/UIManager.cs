using UnityEngine;

namespace UI.Menus
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] GameObject _window;
        public void TurnOnWindow()
        {
            _window.SetActive(true);
        }

        public void TurnOffWindow()
        {
            _window.SetActive(false);
        }
    }
}