public class Jaggernaut : Base
{
    public float ballSizeMultiplier = 2f;

    public override void OnUpgradeBought()
    {
        if (!IsActive()) { return; }
        base.OnUpgradeBought();

        player.AttackSpeed *= 2f;
        player.Damage *= 2;
        player.ShotSpeed *= 2f;
        player.Range *= 2f;
        player.ProjectileSize *= ballSizeMultiplier;
    }
}
