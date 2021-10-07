using UnityEngine;
using TMPro;

public class Lives : MonoBehaviour
{
    public int lives = 200;
    public TextMeshProUGUI livesText;
    DeathController deathController;
    Difficulty difficulty;

    private void OnEnable()
    {
        deathController = FindObjectOfType<DeathController>();
        difficulty = FindObjectOfType<Difficulty>();
        SetDifficultyLives();
        DisplayLives();
    }

    public void TakeLives(int amount)
    {
        lives -= amount;
        DisplayLives();
        if (lives <= 0)
        {
            deathController.RestartScene();
        }
    }

    private void SetDifficultyLives()
    {
        lives = difficulty.GetStartingHealth();
    }

    public void DisplayLives()
    {
        livesText.text = lives.ToString();
    }
}
