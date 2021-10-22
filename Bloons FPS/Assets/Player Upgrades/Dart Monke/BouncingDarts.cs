using UnityEngine;

public class BouncingDarts : Base
{
    public override void OnUpgradeBought()
    {
        if (!IsActive())
        {
            return;
        }
        EnableBounce();
        base.OnUpgradeBought();
    }

    private void EnableBounce()
    {
        player = FindObjectOfType<Player>();
        foreach (ParticleSystem projectile in player.Projectiles)
        {
            ParticleSystem.CollisionModule colliderData = projectile.collision;
            colliderData.bounce = 1f;
            colliderData.dampen = new ParticleSystem.MinMaxCurve(0.5f);
            colliderData.lifetimeLoss = 0f;
        }
    }
}
