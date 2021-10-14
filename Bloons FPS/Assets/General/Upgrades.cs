using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrades : MonoBehaviour
{
    private Player player;
    private Coins coins;

#pragma warning disable IDE0090 // Use 'new(...)'
    public List<Upgrade> upgrades = new List<Upgrade>();
#pragma warning restore IDE0090 // Use 'new(...)'
    public float costIncrease = 1.3f;

    [Serializable]
    public class Upgrade
    {
        public float cost = 10;
        public int damage = 0;
        public float attackSpeed = 0f;
        public float shotSpeed = 0f;
        public float projectileRadius = 0f;
        public float accuracy = 0f;
        public float range = 0f;
    }

    private void Start()
    {
        player = FindObjectOfType<Player>();
        coins = FindObjectOfType<Coins>();
    }

    public bool CheckCost(int index)
    {
        if (upgrades.Count - 1 < index) { return false; }
        Upgrade upgrade = upgrades[index];
        if (upgrade == null) { return false; }

        float currentCoins = coins.coinAmount;
        float cost = upgrade.cost;

        if (currentCoins >= cost)
        {
            coins.LoseCoins(cost);
            upgrade.cost *= costIncrease;
            Buy(index);
            return true;
        }
        return false;
    }

    public bool CanAfford(Upgrade upgrade)
    {
        coins = FindObjectOfType<Coins>();
        float currentCoins = coins.coinAmount;
        float cost = upgrade.cost;
        if (currentCoins >= cost)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void Buy(int index)
    {
        ShopItem[] shopItems = FindObjectsOfType<ShopItem>();
        foreach (ShopItem shopItem in shopItems)
        {
            shopItem.Display();
        }
        Upgrade upgrade = upgrades[index];
        player.IncreaseStats(upgrade.damage, upgrade.attackSpeed, upgrade.shotSpeed, upgrade.projectileRadius, upgrade.accuracy, upgrade.range);
    }
}
