using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Obstacles
{
    public class WaterSpawner : MonoBehaviour
    {
        [SerializeField] private Timer _waterSpawnerTimer;
        [SerializeField] private GameObject _water;
        private void Update()
        {
            if (_waterSpawnerTimer.IsReady)
            {
                var drop = Instantiate(_water, transform);
                drop.transform.parent = gameObject.transform;
                _waterSpawnerTimer.Reset();
            }
        }
    }
}
