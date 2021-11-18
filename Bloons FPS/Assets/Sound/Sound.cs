using UnityEngine;

public class Sound : MonoBehaviour
{
    [Header("Sound effects")]
    public AudioClip popSFX;
    public AudioClip damageSFX;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayStageMusic();
    }

    public void PlayStageMusic()
    {
        audioSource.Play();
    }

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
