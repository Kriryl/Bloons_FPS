using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject notice;
    public GameObject difficultyButton;

    private bool goingToBeActive = true;

    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void CloseNotice()
    {
        notice.SetActive(false);
    }

    public void ToggleDifficultyButton()
    {
        difficultyButton.SetActive(goingToBeActive);
        goingToBeActive = !goingToBeActive;
    }

    public void PlayGame()
    {
        SceneLoader.LoadNextScene();
    }

    public void DifficultySelect(string difficulty)
    {
        Difficulty.SelectDifficulty(difficulty);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
