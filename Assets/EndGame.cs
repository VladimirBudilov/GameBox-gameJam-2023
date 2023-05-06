using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    [SerializeField] private GameObject _blackScreen;

    public void GameOver()
    {
        _blackScreen.SetActive(true);
    }

    public IEnumerable LoadScene()
    {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene("Start Scene");
    }
}
