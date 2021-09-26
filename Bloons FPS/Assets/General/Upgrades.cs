using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrades : MonoBehaviour
{
    private Player player;

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
    }

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    public void Buy(int index)
    {
        Upgrade upgrade = upgrades[index];
        player.ApplyStats(upgrade.damage, upgrade.attackSpeed, upgrade.shotSpeed);
        upgrades.Remove(upgrade);
    }
}
