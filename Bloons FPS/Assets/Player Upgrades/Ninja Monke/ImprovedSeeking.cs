using UnityEngine;

public class ImprovedSeeking : Base
{
    public Seeker seeker;
    public LayerMask layerMask;
    public float rangeMultiplier = 10f;
    public float seeking = 50f;

    public override void OnUpgradeBought()
    {
        if (!AlreadyBought()) { return; }
        base.OnUpgradeBought();

        player.LayerMask = layerMask;
        player.Range *= rangeMultiplier;
        player.Loss = 0.5f;
        player.Dampen = 0.5f;
        seeker.seekSpeed += seeking;
    }
}
