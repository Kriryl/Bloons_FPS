using UnityEngine;

public class AttackSpeed : Base
{
    public float attackSpeedIncrease = 1.5f;

    public override void OnUpgradeBought()
    {
        if (!AlreadyBought())
        {
            return;
        }
        base.OnUpgradeBought();
        player.AttackSpeed *= attackSpeedIncrease;
    }
}
