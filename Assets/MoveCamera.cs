using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using Utils;

public class MoveCamera : MonoBehaviour
{
    [SerializeField] private Timer _timer;
    [SerializeField] private float _byTick = 0.1f;
    private CinemachineVirtualCamera _camera;
    private bool isTouched = false;
    
    void Start()
    {
        _camera = FindObjectOfType<CinemachineVirtualCamera>();
    }
    
    // Update is called once per frame
    void Update()
    {
        
        if (_timer.IsReady || isTouched)
        {
            var temp = _byTick;
            _camera.m_Lens.OrthographicSize = Mathf.Min(temp, 7);
        }
    }

    public void TouchDown()
    {
        isTouched = true;
    }
}
