using UnityEngine;

public class Difficulty : MonoBehaviour
{
    public const string DIFFICULTY = "Difficulty";

    public const int EASY_MODE_HEALTH = 200;
    public const int NORMAL_MODE_HEALTH = 150;
    public const int HARD_MODE_HEALTH = 1;

    public static void SelectDifficulty(string difficulty)
    {
        if (difficulty.ToLower() == "easy")
        {
            PlayerPrefs.SetInt(DIFFICULTY, EASY_MODE_HEALTH);
        }
        else if (difficulty.ToLower() == "medium")
        {
            PlayerPrefs.SetInt(DIFFICULTY, NORMAL_MODE_HEALTH);
        }
        else if (difficulty.ToLower() == "hard")
        {
            PlayerPrefs.SetInt(DIFFICULTY, HARD_MODE_HEALTH);
        }
        else
        {
            print("Error: Difficulty not found");
        }
    }

    public static int GetStartingHealth()
    {
        return PlayerPrefs.GetInt(DIFFICULTY);
    }
}
