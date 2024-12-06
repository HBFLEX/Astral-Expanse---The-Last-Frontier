using UnityEngine;
using UnityEngine.SceneManagement;


public class RestartLevel : Singleton<RestartLevel>
{
    public void RestartGame()
    {
        SceneManager.LoadScene(2); // load the first level scene
    }
}
