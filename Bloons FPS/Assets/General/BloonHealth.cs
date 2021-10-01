using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloonHealth : MonoBehaviour
{
    public int health = 1;
    public AudioClip popsfx;
    public AudioClip damagesfx;

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        if (health <= 0)
        {
            AudioSource.PlayClipAtPoint(popsfx, transform.position);
            Die();
        }
        else
        {
            AudioSource.PlayClipAtPoint(damagesfx, transform.position);
        }
    }

    public void Die()
    {
        BroadcastMessage("OnDeath");
    }
}
