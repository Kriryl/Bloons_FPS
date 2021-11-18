using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject notice;
    public GameObject difficultyButton;

    private bool goingToBeActive = true;

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
}
