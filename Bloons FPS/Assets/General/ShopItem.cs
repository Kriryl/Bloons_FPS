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

    BaseUpgrade baseUpgrade;

    private void Start()
    {
        baseUpgrade = FindObjectOfType<BaseUpgrade>();
    }

    public void Display()
    {
        baseUpgrade = FindObjectOfType<BaseUpgrade>();
        costText.text = baseUpgrade.GetCost().ToString();
    }

    public void ButItem()
    {
        if (!isLocked)
        {
            isLocked = true;
            Display();
            baseUpgrade.OnUpgrade();
        }
    }
}
