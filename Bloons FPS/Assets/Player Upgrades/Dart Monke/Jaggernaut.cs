using UnityEngine;

public class Jaggernaut : Base
{
    public float ballSizeMultiplier = 2f;

    public override void OnUpgradeBought()
    {
        if (!IsActive()) { return; }
        base.OnUpgradeBought();

        player.AttackSpeed *= 2f;
        player.Damage *= 2;
        player.ShotSpeed *= 1.5f;
        player.Range *= 10f;

        foreach (ParticleSystem projectile in player.Projectiles)
        {
            var statSize = projectile.main;
            statSize.startSize = new ParticleSystem.MinMaxCurve(statSize.startSize.constant * ballSizeMultiplier);
        }
    }
}
