using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    public bool isLocked = false;
    public int shopIndex = 0;
    public TextMeshProUGUI upgradeText;
    public TextMeshProUGUI costText;
    public string upgradeName = "Item";
    public Image background;

    Upgrades upgrades;
    Upgrades.Upgrade upgrade;
    float cost;
    Color startColor;

    private void Start()
    {
        startColor = background.color;
        upgrades = FindObjectOfType<Upgrades>();
        upgradeText.text = upgradeName;
        upgrade = upgrades.upgrades[shopIndex];
        cost = upgrade.cost;
    }

    public void BuyItem()
    {
        if (!isLocked)
        {
            if (upgrades.CheckCost(shopIndex))
            {
                print($"Succesfully bought {upgradeName}");
            }
        }
        Display();
    }

    public void Display()
    {
        upgrades = FindObjectOfType<Upgrades>();
        upgrade = upgrades.upgrades[shopIndex];
        cost = upgrade.cost;
        startColor = Color.green;
        float cleanCost = Mathf.Round(cost * 10) / 10;
        costText.text = $"${cleanCost}";
        background.color = upgrades.CanAfford(upgrade) ? startColor : Color.red;
    }
}
