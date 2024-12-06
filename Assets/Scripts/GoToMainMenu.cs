using UnityEngine;
using UnityEngine.SceneManagement;



public class GoToMainMenu : MonoBehaviour
{
    private void OnEnable()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void GoBackToMainMenu()
    {
        SceneManager.LoadScene(1);
    }
}
