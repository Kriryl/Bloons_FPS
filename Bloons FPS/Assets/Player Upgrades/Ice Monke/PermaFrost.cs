public class PermaFrost : Base
{
    public float speedMultiplier = 0.65f;
    private bool effectActive = false;

    public override void OnUpgradeBought()
    {
        if (!AlreadyBought()) { return; }
        base.OnUpgradeBought();

        effectActive = true;
    }

    internal void OnBloonCooled(BloonType bloon)
    {
        if (effectActive)
        {
            bloon.Speed = bloon.StartingSpeed * speedMultiplier;
        }
    }
}
