using UnityEngine;

public class Difficulty : MonoBehaviour
{
    public const int EASY_MODE_HEALTH = 200;
    public const int NORMAL_MODE_HEALTH = 150;
    public const int HARD_MODE_HEALTH = 1;

    public enum DifficultyMode { easy, normal, hard }

    public DifficultyMode CurrentDifficulty { get; private set; }

    public void SelectDifficulty(string difficulty)
    {
        if (difficulty.ToLower() == "easy")
        {
            CurrentDifficulty = DifficultyMode.easy;
        }
        else if (difficulty.ToLower() == "normal")
        {
            CurrentDifficulty = DifficultyMode.normal;
        }
        else if (difficulty.ToLower() == "hard")
        {
            CurrentDifficulty = DifficultyMode.hard;
        }
        BroadcastMessage("OnDifficultySelect");
    }

    public int GetStartingHealth()
    {
        if (CurrentDifficulty == DifficultyMode.easy)
        {
            return EASY_MODE_HEALTH;
        }
        else if (CurrentDifficulty == DifficultyMode.normal)
        {
            return NORMAL_MODE_HEALTH;
        }
        else if (CurrentDifficulty == DifficultyMode.normal)
        {
            return HARD_MODE_HEALTH;
        }
        else
        {
            return NORMAL_MODE_HEALTH;
        }
    }
}
