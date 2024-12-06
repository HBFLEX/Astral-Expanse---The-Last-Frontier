using UnityEngine;
using UnityEngine.SceneManagement;


public class RestartLevel : Singleton<RestartLevel>
{
    [SerializeField] private string transitionName;
    public void RestartGame()
    {
        if (transitionName == SceneManagement.Instance.SceneTransitionName) {
            PlayerController.Instance.transform.position = this.transform.position;
            CameraController.Instance.SetPlayerCameraFollow();
            UIFade.Instance.FadeToClear();
        }
    }
}
