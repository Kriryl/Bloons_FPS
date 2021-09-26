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

    public void AddCoins(int amount)
    {
        coinAmount += amount;
        DisplayCoins();
    }

    public void LoseCoins(int cost)
    {
        coinAmount -= cost;
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
