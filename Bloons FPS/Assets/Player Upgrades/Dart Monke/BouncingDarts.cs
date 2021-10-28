using UnityEngine;

public class BouncingDarts : Base
{
    public override void OnUpgradeBought()
    {
        if (!IsActive())
        {
            return;
        }
        base.OnUpgradeBought();
        player.Bounce = 1f;
        player.Dampen = 0.5f;
        player.Loss = 0f;
    }
}
