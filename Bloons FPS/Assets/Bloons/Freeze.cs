using UnityEngine;
using System.Collections;

public class Freeze : MonoBehaviour
{
    public float freezeDuration = 1f;
    public GameObject freezeVFX;

    internal void OnBloonDeath(BloonType[] bloons)
    {
        if (bloons.Length <= 0) { return; }

        foreach (BloonType bloon in bloons)
        {
            bloon.Freeze();
            GameObject newFreezeEffect = Instantiate(freezeVFX, bloon.transform);
            newFreezeEffect.transform.localPosition = new Vector3(0f, 0.65f, 0f);
            _ = StartCoroutine(UnfreezeBloon(bloon, newFreezeEffect));
        }
    }

    private IEnumerator UnfreezeBloon(BloonType bloon, GameObject vfx)
    {
        yield return new WaitForSeconds(freezeDuration);
        bloon.SetNormalSpeed();
        GlobalEventManager.CallEvent("OnBloonCooled", bloon);
        Destroy(vfx);
    }
}
