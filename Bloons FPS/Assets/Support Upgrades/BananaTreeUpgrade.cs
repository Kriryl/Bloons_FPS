using UnityEngine;

public class BananaTreeUpgrade : Base
{
    public GameObject bananaTree;

    public override void OnSupportUpgradeBought()
    {
        if (!AlreadyBought()) { return; }
        base.OnSupportUpgradeBought();

        bananaTree.SetActive(true);
    }
}
