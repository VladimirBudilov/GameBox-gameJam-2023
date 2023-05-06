using Components.Audio;
using TMPro;
using UnityEngine;

namespace UI.Menus
{
    public class DeathScreenComponent : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _deathSentence;
        [SerializeField] private PlaySoundComponent _sound;
        [SerializeField] private string _deathByFallText;
        [SerializeField] private string _deathBySanityText;

        public void Death(string id)
        {
            _sound.Play(id);
            switch (id)
            {
                case "sanity":
                {
                    _deathSentence.text = _deathBySanityText;
                    break;
                }
                case "fall":
                {
                    _deathSentence.text = _deathByFallText;
                    break;
                }
            }
        }
    }
}