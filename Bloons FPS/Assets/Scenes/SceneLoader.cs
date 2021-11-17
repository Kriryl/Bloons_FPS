using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    /// <summary>
    /// Returns the current scene index.
    /// </summary>
    /// <returns>The scene index for the current scene.</returns>
    public static int GetCurrentScene()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }

    public static void LoadScene(int index)
    {
        if (!SceneExists(index)) { return; }
        SceneManager.LoadScene(index);
    }

    private static bool SceneExists(int index)
    {
        return index <= SceneManager.sceneCountInBuildSettings;
    }

    /// <summary>
    /// Loads the next scene.
    /// </summary>
    public static void LoadNextScene()
    {
        if (!SceneExists(GetCurrentScene() + 1)) { return; }
        SceneManager.LoadScene(GetCurrentScene() + 1);
    }

    public static void RestartScene()
    {
        SceneManager.LoadScene(GetCurrentScene());
    }

    public static AsyncOperation GetAsync(int index)
    {
        return SceneManager.LoadSceneAsync(index);
    }

    public static void PlayAgain()
    {
        SceneManager.LoadScene(0);
    }
}
