using UnityEngine;

public class SpikedBall : Base
{
    public GameObject ballProjectile;

    public override void OnUpgradeBought()
    {
        if (!AlreadyBought()) { return; }

        base.OnUpgradeBought();

        player.Damage *= 2;
        player.Range *= 1.5f;
        player.ShotSpeed += 5f;
        player.Mesh = ballProjectile.transform.GetChild(0).GetComponent<MeshFilter>().mesh;
    }
}
