using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField] private GameObject _blackScreen;

    public void GameOver()
    {
        _blackScreen.SetActive(true);
    }
}
