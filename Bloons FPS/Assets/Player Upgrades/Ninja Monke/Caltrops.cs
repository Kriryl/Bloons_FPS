using UnityEngine;

public class Caltrops : Base
{
    public GameObject caltropSpawner;
    public Vector3 pos;

    public override void OnUpgradeBought()
    {
        if (!AlreadyBought()) { return; }
        base.OnUpgradeBought();

        player.AddIndepententBullet(caltropSpawner, pos);
    }
}
