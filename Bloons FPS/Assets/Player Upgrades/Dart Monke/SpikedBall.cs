using UnityEngine;

public class SpikedBall : Base
{
    public Mesh ballProjectile;

    public override void OnUpgradeBought()
    {
        if (!IsActive()) { return; }

        player = FindObjectOfType<Player>();
        player.Damage *= 2;
        player.ShotSpeed *= 1.5f;
        player.Range *= 2f;
        player.AttackSpeed *= 0.8f;

        foreach (ParticleSystem projectile in player.Projectiles)
        {
            ParticleSystemRenderer particleSystemRenderer = projectile.GetComponent<ParticleSystemRenderer>();
            particleSystemRenderer.mesh = ballProjectile;
        }

        base.OnUpgradeBought();
    }
}
