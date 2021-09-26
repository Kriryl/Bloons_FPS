using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public const KeyCode INTERACT = KeyCode.E;
    public int buyIndex = 0;

    Upgrades upgrades;

    private void Start()
    {
        upgrades = FindObjectOfType<Upgrades>();
    }

    private void OnCollisionStay(Collision collision)
    {
        if (Input.GetKeyDown(INTERACT))
        {
            BuyItem();
        }
    }

    private void BuyItem()
    {
        if (upgrades.CheckCost(buyIndex))
        {
            buyIndex++;
        }
    }
}
