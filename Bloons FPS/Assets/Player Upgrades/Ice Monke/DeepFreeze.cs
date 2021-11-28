public class DeepFreeze : Base
{
    public override void OnUpgradeBought()
    {
        if (!AlreadyBought()) { return; }
        base.OnUpgradeBought();

        player.Damage += 1;
    }
}
