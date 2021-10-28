using UnityEngine;
using TMPro;

public class Shop : MonoBehaviour
{
    public const KeyCode INTERACT = KeyCode.E;
    public bool isOpen = false;

    public Canvas shopCanvas;

    private void Start()
    {
        shopCanvas.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (!isOpen)
        {
            if (Input.GetKeyDown(INTERACT))
            {
                OpenShop();
            }
        }
        else if (isOpen)
        {
            if (Input.GetKeyDown(INTERACT))
            {
                Cursor.lockState = CursorLockMode.Locked;
                isOpen = false;
                shopCanvas.gameObject.SetActive(false);
                Cursor.visible = false;
                Time.timeScale = 1f;
            }
        }
    }

    private void OpenShop()
    {
        ShopItem[] shopItems = FindObjectsOfType<ShopItem>(true);
        foreach (ShopItem shopItem in shopItems)
        {
            shopItem.Display();
        }
        isOpen = true;
        shopCanvas.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
    }
}
