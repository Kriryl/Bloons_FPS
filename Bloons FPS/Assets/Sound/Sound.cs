using UnityEngine;

public class Sound : MonoBehaviour
{
    public AudioClip popSFX;
    public AudioClip damageSFX;

    public void OnBloonSpawn()
    {
        BloonHealth[] bloonHealths = FindObjectsOfType<BloonHealth>();

        foreach (BloonHealth bloonHealth in bloonHealths)
        {
            bloonHealth.popsfx = popSFX;
            bloonHealth.popsfx = popSFX;
        }
    }
}
