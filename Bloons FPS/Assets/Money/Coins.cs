using TMPro;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public float coinAmount = 0;

    public TextMeshProUGUI coinText;

    private void Start()
    {
        DisplayCoins();
    }

    public void AddCoins(float amount)
    {
        coinAmount += amount;
        DisplayCoins();
    }

    public void LoseCoins(float cost)
    {
        coinAmount -= cost;
        DisplayCoins();
    }

    public void DisplayCoins()
    {
        if (coinText)
        {
            float cleanCost = Mathf.Round(coinAmount * 10) / 10;
            coinText.text = $"${cleanCost}";
        }
    }
}
