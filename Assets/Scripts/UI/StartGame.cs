using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    PauseManager pauseManager;
    public void StartGameplay()
    {
        pauseManager = GetComponent<PauseManager>();
        pauseManager.UnPauseGame();
        SceneManager.LoadScene("Essential", LoadSceneMode.Single);
        SceneManager.LoadScene("GameplayStage", LoadSceneMode.Additive);
    }
}
