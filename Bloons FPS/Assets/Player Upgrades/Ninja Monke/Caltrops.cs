using UnityEngine;

public class Caltrops : Base
{
    public ParticleSystem caltropSpawner;
    public Vector3 pos;

    public override void OnUpgradeBought()
    {
        if (!IsActive()) { return; }
        base.OnUpgradeBought();

        player.AddIndepententBullet(caltropSpawner, pos);
    }
}
