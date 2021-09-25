using TMPro;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public int coinAmount = 0;

    public TextMeshProUGUI coinText;

    private void Start()
    {
        DisplayCoins();
    }

    public void AddCoins(float amount)
    {
        coinAmount += (int)amount;
        DisplayCoins();
    }

    public void LoseCoins(float cost)
    {
        coinAmount -= (int)cost;
        DisplayCoins();
    }

    public void DisplayCoins()
    {
        if (coinText)
        {
            coinText.text = $"$ {coinAmount}";
        }
    }
}
