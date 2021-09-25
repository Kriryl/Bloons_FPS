using UnityEditor.ProBuilder;
using UnityEngine;

public class BloonType : Bloon
{
    public BloonType[] children;
    public float speed = 5f;
    public bool On = true;
    public string bloonName = "Tets Bloon";

    private void Update()
    {
        IsOn = On;
        SeekPlayer(speed);
    }

    private void OnParticleCollision(GameObject other)
    {
        print("asfha");
        Damage damage = other.GetComponentInParent<Damage>();
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

    internal void OnDeath()
    {
        if (children.Length <= 0) { return; }
        foreach (BloonType bloonType in children)
        {
            Instantiate(bloonType, transform.position, transform.rotation).name = bloonType.bloonName;
        }
    }
}
