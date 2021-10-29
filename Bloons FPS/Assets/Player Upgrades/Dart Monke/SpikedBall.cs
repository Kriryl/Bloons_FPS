using UnityEngine;

public class SpikedBall : Base
{
    public Mesh ballProjectile;

    public override void OnUpgradeBought()
    {
        if (!IsActive()) { return; }

        base.OnUpgradeBought();

        player.Damage *= 2;
        player.Range *= 1.5f;
        player.ShotSpeed += 5f;
        player.Mesh = ballProjectile;
    }
}
