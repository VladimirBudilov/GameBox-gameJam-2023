using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Model
{
    public class PlayerDeath : MonoBehaviour
    {
        public void Death(string deathId)
        {
            Debug.Log($"Death by {deathId}");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }
}