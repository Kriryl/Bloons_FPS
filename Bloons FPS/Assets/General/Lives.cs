using UnityEngine;
using TMPro;

public class Lives : MonoBehaviour
{
    public int lives = 200;
    public TextMeshProUGUI livesText;
    DeathController deathController;

    private void OnEnable()
    {
        deathController = FindObjectOfType<DeathController>();
        SetDifficultyLives();
        DisplayLives();
    }

    public void TakeLives(int amount)
    {
        lives -= amount;
        DisplayLives();
        if (lives <= 0)
        {
            deathController.Restart();
        }
    }

    private void SetDifficultyLives()
    {
        int retrievedLives = Difficulty.GetStartingHealth();
        lives = retrievedLives <= 0 ? 150 : Difficulty.GetStartingHealth();
    }

    public void DisplayLives()
    {
        livesText.text = lives.ToString();
    }
}
