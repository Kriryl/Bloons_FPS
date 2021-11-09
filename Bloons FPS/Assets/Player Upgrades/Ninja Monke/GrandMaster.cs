using UnityEngine;

public class GrandMaster : Base
{
    public int projectileAddAmount = 4;
    public Vector3 pos = Vector3.zero;

    public override void OnUpgradeBought()
    {
        if (!AlreadyBought()) { return; }
        base.OnUpgradeBought();

        player.AddBullet(projectileAddAmount, pos);
        player.AttackSpeed *= 2f;
        player.Damage += 1;
    }
}
