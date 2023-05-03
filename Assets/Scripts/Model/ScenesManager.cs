using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public void LoadStartScene()
    {
        SceneManager.LoadScene("DemoScene");
    }
}
