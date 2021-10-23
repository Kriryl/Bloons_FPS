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

    private void OnEnable()
    {
        Display();
    }

    public void Display()
    {
        baseUpgrade = FindObjectOfType<BaseUpgrade>();
        upgradeText.text = upgradeName;
        costText.text = baseUpgrade.GetCost(shopIndex).ToString();
        background.color = baseUpgrade.CanAfford(shopIndex) ? Color.green : Color.red;
    }

    public void ButItem()
    {
        if (!isLocked && baseUpgrade.CanAfford(shopIndex))
        {
            isLocked = true;
            Display();
            baseUpgrade.OnUpgrade(shopIndex);
        }
    }
}
