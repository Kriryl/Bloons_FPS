using UnityEngine;
using TMPro;

public class Lives : MonoBehaviour
{
    public int lives = 200;
    public TextMeshProUGUI livesText;
    DeathController deathController;

    private void Start()
    {
        deathController = FindObjectOfType<DeathController>();
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

    public void DisplayLives()
    {
        livesText.text = lives.ToString();
    }
}
