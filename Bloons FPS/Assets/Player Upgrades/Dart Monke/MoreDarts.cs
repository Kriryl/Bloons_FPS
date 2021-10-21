using UnityEngine;

public class MoreDarts : Base
{
    public ParticleSystem extraDart;
    public Vector3 pos;
    public override void OnUpgradeBought()
    {
        if (!IsActive())
        {
            return;
        }
        base.OnUpgradeBought();
        player.AddBullet(Instantiate(extraDart), pos);
    }
}
