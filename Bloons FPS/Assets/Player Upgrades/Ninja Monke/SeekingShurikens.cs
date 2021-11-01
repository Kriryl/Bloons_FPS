public class SeekingShurikens : Base
{
    public Seeker seeker;

    public override void OnUpgradeBought()
    {
        if (!IsActive()) { return; }
        base.OnUpgradeBought();

        player.Range *= 2f;
        seeker.enabled = true;
    }
}
