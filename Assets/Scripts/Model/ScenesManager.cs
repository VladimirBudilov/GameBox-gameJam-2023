using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public void LoadStartScene()
    {
        SceneManager.LoadScene("Scenes/Demo Scene");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
