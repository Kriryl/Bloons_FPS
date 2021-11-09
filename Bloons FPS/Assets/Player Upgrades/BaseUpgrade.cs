using UnityEngine;
using System;

public class BaseUpgrade : MonoBehaviour
{
    public UpgradePath[] upgrades;
    public SupportPath[] supportUpgrades;
    private int supportLenght = 0;
    private int pathLenght = 0;
    private Coins coins;

    private void Start()
    {
        supportLenght = supportUpgrades.Length;
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
        public float cost = 10f;
    }

    [Serializable]
    public class SupportPath
    {
        public Base supportBehaviour;
        public float cost = 10f;
    }

    public void OnUpgrade(int index, bool isSupport)
    {
        if (isSupport)
        {
            if (index + 1 <= supportLenght)
            {
                float cost = supportUpgrades[index].cost;
                coins.LoseCoins(cost);
                supportUpgrades[index].supportBehaviour.enabled = true;
                BroadcastMessage("OnSupportUpgradeBought");
            }
        }
        else
        {
            if (index + 1 <= pathLenght)
            {
                float cost = upgrades[index].cost;
                coins.LoseCoins(cost);
                upgrades[index].upgradeBehaviour.enabled = true;
                BroadcastMessage("OnUpgradeBought");
            }
        }
    }
}
