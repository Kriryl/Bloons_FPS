using UnityEngine;

public class PauseScreen : MonoBehaviour
{
    public GameObject pauseScreen;
    private bool isPaused = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    private void TogglePause()
    {
        if (isPaused)
        {
            UnpauseGame();
        }
        else if (!isPaused)
        {
            PauseGame();
        }
    }

    private void OnApplicationFocus(bool focus)
    {
        if (focus == false)
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        pauseScreen.SetActive(true);
        isPaused = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
    }

    public void UnpauseGame()
    {
        pauseScreen.SetActive(false);
        isPaused = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
    }

    public void MainMenu()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 1f;
        SceneLoader.ReturnToMainMenu();
    }

    public void Retry()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 1f;
        SceneLoader.RestartScene();
    }
}
