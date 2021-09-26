using UnityEngine;
using TMPro;

public class Lives : MonoBehaviour
{
    public int lives = 200;
    public TextMeshProUGUI livesText;

    private void Start()
    {
        DisplayLives();
    }

    public void TakeLives(int amount)
    {
        lives -= amount;
        DisplayLives();
    }

    public void DisplayLives()
    {
        livesText.text = lives.ToString();
    }
}
