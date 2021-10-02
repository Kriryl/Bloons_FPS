using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathController : MonoBehaviour
{
    int currentScene = 0;

    public int GetCurrentScene()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        return currentScene;
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(GetCurrentScene());
    }
}
