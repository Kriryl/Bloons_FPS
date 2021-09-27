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

    [Serializable]
    public class Upgrade
    {
        public float cost = 10f;
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

        int currentCoins = coins.coinAmount;
        int cost = (int)upgrade.cost;

        if (currentCoins >= cost)
        {
            coins.LoseCoins(cost);
            Buy(index);
            return true;
        }
        return false;
    }

    private void Buy(int index)
    {
        Upgrade upgrade = upgrades[index];
        player.IncreaseStats(upgrade.damage, upgrade.attackSpeed, upgrade.shotSpeed, upgrade.projectileRadius, upgrade.accuracy, upgrade.range);
    }
}
