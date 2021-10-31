public class NinjaDicipline : Base
{
    public override void OnUpgradeBought()
    {
        if (!IsActive()) { return; }
        base.OnUpgradeBought();
        player.AttackSpeed *= 1.5f;
        player.Range += 0.2f;
    }
}
