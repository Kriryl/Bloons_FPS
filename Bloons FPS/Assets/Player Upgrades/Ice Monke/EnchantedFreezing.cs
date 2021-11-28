public class EnchantedFreezing : Base
{
    public float attackSpeed = 2f;
    public float freezeDuration = 1.5f;

    public override void OnUpgradeBought()
    {
        if (!AlreadyBought()) { return; }
        base.OnUpgradeBought();

        player.AttackSpeed *= attackSpeed;
        GetComponent<Freeze>().freezeDuration *= freezeDuration;
    }
}
