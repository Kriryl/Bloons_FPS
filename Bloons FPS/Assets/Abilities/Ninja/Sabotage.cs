using UnityEngine;

public class Sabotage : BaseAbility
{
    public ParticleSystem sabotage;

    public override void OnActivate()
    {
        BloonType[] bloons = BloonType.GetAllBloons();
        foreach (BloonType bloon in bloons)
        {
            _ = Instantiate(sabotage, bloon.transform);
            bloon.speed /= 2f;
        }
        base.OnActivate();
    }

    public override void OnAbilityEnd()
    {
        BloonType[] bloons = BloonType.GetAllBloons();
        foreach (BloonType bloon in bloons)
        {
            bloon.SetNormalSpeed();
        }
        base.OnAbilityEnd();
    }
}
