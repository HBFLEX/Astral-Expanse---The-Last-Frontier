using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YouDiedController : Singleton<YouDiedController>
{
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private Canvas canvas;

    private void Update()
    {
        if (playerHealth.currentHealth <= 0)
        {
            canvas.enabled = true;
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(1);
    }
}
