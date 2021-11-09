using UnityEngine;

public class BouncingDarts : Base
{
    public override void OnUpgradeBought()
    {
        if (!AlreadyBought())
        {
            return;
        }
        base.OnUpgradeBought();
        player.Range += 0.2f;
        player.Bounce = 1f;
        player.Dampen = 0.5f;
        player.Loss = 0f;
    }
}
