using UnityEngine;
using System.Collections;

public class SnowStorm : BaseAbility
{
    public Freeze freeze;
    public override void OnActivate()
    {
        foreach (BloonType bloon in BloonType.GetAllBloons())
        {
            bloon.Freeze();
            _ = StartCoroutine(WaitForUnfreeze(bloon, freeze.ApplyFreeze(bloon)));
        }

        base.OnActivate();
    }

    private IEnumerator WaitForUnfreeze(BloonType bloon, GameObject freezeEffect)
    {
        yield return new WaitForSeconds(freeze.freezeDuration);
        bloon.Unfreeze();
        Destroy(freezeEffect);
    }
}
