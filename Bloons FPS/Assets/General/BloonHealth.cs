using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloonHealth : MonoBehaviour
{
    public int health = 1;

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        BroadcastMessage("OnDeath");
    }
}
