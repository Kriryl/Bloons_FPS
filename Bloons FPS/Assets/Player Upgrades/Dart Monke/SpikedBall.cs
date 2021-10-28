using UnityEngine;

public class SpikedBall : Base
{
    public Mesh ballProjectile;

    public override void OnUpgradeBought()
    {
        if (!IsActive()) { return; }

        base.OnUpgradeBought();

        player.Damage *= 2;
        player.Range *= 2f;
        player.Mesh = ballProjectile;
    }
}
