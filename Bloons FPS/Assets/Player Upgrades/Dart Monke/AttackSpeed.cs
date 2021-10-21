using UnityEngine;

public class AttackSpeed : Base
{
    public float attackSpeedIncrease = 1.5f;

    public override void OnUpgradeBought()
    {
        if (!IsActive())
        {
            return;
        }
        player = FindObjectOfType<Player>();
        player.AttackSpeed *= attackSpeedIncrease;
        base.OnUpgradeBought();
    }
}