using UnityEngine;
using System;

public class BaseUpgrade : MonoBehaviour
{
    public UpgradePath[] upgrades;
    private int pathLenght = 0;

    private void Start()
    {
        pathLenght = upgrades.Length;
        foreach(UpgradePath behaviour in upgrades)
        {
            behaviour.upgradeBehaviour.enabled = false;
        }
    }

    public float GetCost(int index)
    {
        return upgrades[index].cost;
    }

    [Serializable]
    public class UpgradePath
    {
        public Base upgradeBehaviour;
        public float cost = 10f;
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
