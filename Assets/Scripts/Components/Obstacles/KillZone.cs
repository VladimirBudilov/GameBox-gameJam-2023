namespace Obstacles
{
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class KillZone : MonoBehaviour
    {
        public void ResetScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}