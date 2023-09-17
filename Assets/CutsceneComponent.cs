using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Utils;

public class CutsceneComponent : MonoBehaviour
{
    [SerializeField] private Timer _timeForSlide;
    [SerializeField] private Image _cutsceneImage;
    [SerializeField] private Sprite[] _slides;
    private int _currentSlide;

    private void Start()
    {
        _timeForSlide.Reset();
        _currentSlide = 0;
        _cutsceneImage.sprite = _slides[_currentSlide];
    }

    private void Update()
    {
        if (_timeForSlide.IsReady)
        {
            _currentSlide++;
            if (_currentSlide == _slides.Length)
            {
                SceneManager.LoadScene("Level_01");
                return;
            }
            _cutsceneImage.sprite = _slides[_currentSlide];
            _timeForSlide.Reset();
        }
    }
}
