using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrades : MonoBehaviour
{
    private Player player;
    private BananaTree bananaTree;
    private Coins coins;
    public List<Upgrade> upgrades = new List<Upgrade>();
    public List<BananaItem> bananaItems;
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

    [Serializable]
    public class BananaItem
    {
        public float cost = 20f;
        public float bananaSpawnRate = 0f;
        public float bananaValue = 0f;
    }

    private void Start()
    {
        player = FindObjectOfType<Player>();
        bananaTree = FindObjectOfType<BananaTree>();
        coins = FindObjectOfType<Coins>();
    }

    public bool CheckCost(int index, bool bananaRelated)
    {
        if (!bananaRelated)
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
                Buy(index, false);
                return true;
            }
            return false;
        }
        else
        {
            if (bananaItems.Count - 1 < index) { return false; }
            BananaItem bananaItem = bananaItems[index];
            if (bananaItem == null) { return false; }

            float currentCoins = coins.coinAmount;
            float cost = bananaItem.cost;

            if (currentCoins >= cost)
            {
                coins.LoseCoins(cost);
                bananaItem.cost *= costIncrease;
                Buy(index, true);
                return true;
            }
            return false;
        }
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

    public bool CanAfford(BananaItem bananaItem)
    {
        coins = FindObjectOfType<Coins>();
        float currentCoins = coins.coinAmount;
        float cost = bananaItem.cost;
        if (currentCoins >= cost)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void Buy(int index, bool isBanana)
    {
        ShopItem[] shopItems = FindObjectsOfType<ShopItem>();
        foreach (ShopItem shopItem in shopItems)
        {
            shopItem.Display();
        }
        if (!isBanana)
        {
            Upgrade upgrade = upgrades[index];
            player.IncreaseStats(upgrade.damage, upgrade.attackSpeed, upgrade.shotSpeed, upgrade.projectileRadius, upgrade.accuracy, upgrade.range);
        }
        else
        {
            BananaItem bananaItem = bananaItems[index];
            bananaTree.IncreaseStats(bananaItem.bananaSpawnRate, bananaItem.bananaValue);
        }
    }
}
