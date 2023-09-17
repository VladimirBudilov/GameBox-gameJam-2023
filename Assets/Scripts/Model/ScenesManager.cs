using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public void LoadStartScene()
    {
        SceneManager.LoadScene("BeginCutscene");
    }

    public void LoadAutorhsScene()
    {
        SceneManager.LoadScene("AuthorsScene");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
