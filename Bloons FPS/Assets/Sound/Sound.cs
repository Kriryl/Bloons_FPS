using UnityEngine;

public class Sound : MonoBehaviour
{
    public AudioClip audioClip;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    internal void PlaySound()
    {
        audioSource.Play();
    }

    internal void PlayInWorld()
    {
        AudioSource.PlayClipAtPoint(audioClip, transform.position);
    }
}
