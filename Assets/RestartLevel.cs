using UnityEngine;
using UnityEngine.SceneManagement;


public class RestartLevel : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene(2); // load the first level scene
    }
}
