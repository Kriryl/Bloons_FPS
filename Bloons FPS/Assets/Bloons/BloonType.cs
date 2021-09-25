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

    private void OnCollisionEnter(Collision collision)
    {
        Damage damage = collision.gameObject.transform.parent.parent.GetComponent<Damage>();
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
