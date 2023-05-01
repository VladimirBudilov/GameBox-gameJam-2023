using System;
using Model;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace UI
{
    public class FireflyLightBar : MonoBehaviour
    {
        private Slider _fireflyLightBar;

        private void Awake()
        {
            _fireflyLightBar = GetComponent<Slider>();
        }

        private void Start()
        {
            GameSession.Instance.PlayerData.FireflyLight.OnChanged += OnFireflyLightChanged;
        }

        private void OnFireflyLightChanged(float newvalue, float _)
        {
            _fireflyLightBar.value = newvalue;
        }
        
        private void OnDestroy()
        {
            GameSession.Instance.PlayerData.FireflyLight.OnChanged -= OnFireflyLightChanged;
        }
    }
        
}