using UnityEngine;
using System;

public class BaseUpgrade : MonoBehaviour
{
    public UpgradePath[] upgrades;
    private int pathLenght = 0;
    private Coins coins;

    private void Start()
    {
        pathLenght = upgrades.Length;
        foreach(UpgradePath behaviour in upgrades)
        {
            behaviour.upgradeBehaviour.enabled = false;
        }
        coins = FindObjectOfType<Coins>();
    }

    public float GetCost(int index)
    {
        return upgrades[index].cost;
    }

    public bool CanAfford(int index)
    {
        coins = FindObjectOfType<Coins>();
        float currentCoins = coins.coinAmount;
        return currentCoins >= upgrades[index].cost;
    }

    [Serializable]
    public class UpgradePath
    {
        public Base upgradeBehaviour;
        public float cost = 10;
    }

    public void OnUpgrade(int index)
    {
        if (index + 1 <= pathLenght)
        {
            upgrades[index].upgradeBehaviour.enabled = true;
            BroadcastMessage("OnUpgradeBought");
        }
    }
}
