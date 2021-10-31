public class SeekingShurikens : Base
{
    public Seeker seeker;

    public override void OnUpgradeBought()
    {
        if (!IsActive()) { return; }
        base.OnUpgradeBought();

        seeker.enabled = true;
    }
}
