using System;
using System.Collections;
using System.Collections.Generic;
using Model;
using Player;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace UI
{
    public class SanityBar : MonoBehaviour
    {
        private Slider _sanityBar;

        private void Awake()
        {
            _sanityBar = GetComponent<Slider>();
        }

        private void Start()
        {
            GameSession.Instance.PlayerData.Sanity.OnChanged += OnSanityChanged;
        }

        private void OnSanityChanged(float newvalue, float _)
        {
            _sanityBar.value = newvalue;
        }

        private void OnDestroy()
        {
            GameSession.Instance.PlayerData.Sanity.OnChanged -= OnSanityChanged;
        }
    }
}
