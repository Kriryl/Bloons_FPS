using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShopItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool isLocked = false;
    public bool isSupport = false;
    public int shopIndex = 0;
    public TextMeshProUGUI upgradeText;
    public TextMeshProUGUI costText;
    public string upgradeName = "Item";
    public string description = "Item description";
    public Image background;

    TooltipShow tooltipShow;
    BaseUpgrade baseUpgrade;

    private void Start()
    {
        tooltipShow = FindObjectOfType<TooltipShow>();
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
        if (isLocked)
        {
            background.color = Color.gray;
        }
        else
        {
            background.color = baseUpgrade.CanAfford(shopIndex) ? Color.green : Color.red;
        }
    }

    public void BuyItem()
    {
        if (!isLocked && baseUpgrade.CanAfford(shopIndex))
        {
            isLocked = true;
            ShopItem[] shopItems = FindObjectsOfType<ShopItem>(true);
            foreach (ShopItem shopItem in shopItems)
            {
                shopItem.Display();
            }
            baseUpgrade.OnUpgrade(shopIndex, isSupport);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (isLocked)
        {
            description = "Already bought";
        }
        tooltipShow.tooltip = description;
        tooltipShow.Show();
        tooltipShow.canvas.transform.position = tooltipShow.GetMousePos();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltipShow.Hide();
    }
}
