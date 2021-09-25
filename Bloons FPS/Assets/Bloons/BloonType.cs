using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloonType : Bloon
{
    public BloonType[] children;
    public float speed = 5f;

    private void Update()
    {
        SeekPlayer(speed);
    }

    private void OnParticleCollision(GameObject other)
    {
        print("asfha");
        Damage damage = other.GetComponent<Damage>();
        print(damage != null);
        if (damage)
        {
            OnDamageTaken(damage.damage);
        }
    }

    public override void OnDamageTaken(int damageAmount)
    {
        print("damage");
        base.OnDamageTaken(damageAmount);
    }

    public override void SeekPlayer(float speed)
    {
        print("Blon");
        base.SeekPlayer(speed);
    }
}
