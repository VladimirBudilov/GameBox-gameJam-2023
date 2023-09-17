using Cinemachine;
using UnityEngine;
using Utils;

public class MoveCamera : MonoBehaviour
{
    [SerializeField] private Timer _timer;
    [SerializeField] private float _byTick = 0.1f;
    private CinemachineVirtualCamera _camera;
    private bool _isTouched = false;
    private float _currentOrtSize = 0.4f;
    
    void Start()
    {
        _camera = FindObjectOfType<CinemachineVirtualCamera>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (_timer.IsReady && _isTouched)
        {
            _currentOrtSize += _byTick;
            _camera.m_Lens.OrthographicSize = Mathf.Min(_currentOrtSize, 7);
        }
    }

    public void TouchDown()
    {
        _isTouched = true;
    }
}
