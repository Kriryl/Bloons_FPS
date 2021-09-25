using UnityEditor.ProBuilder;
using UnityEngine;

public class BloonType : Bloon
{
    public BloonType[] children;
    public float speed = 5f;
    public bool On = true;
    public string bloonName = "Test Bloon";
    public float coinsOnDamage = 1f;
    public ParticleSystem popvfx;

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
            OnDamageTaken(damage.damage, coinsOnDamage);
        }
    }

    public override void OnDamageTaken(int damageAmount, float coinsToAdd)
    {
        print("damage");
        base.OnDamageTaken(damageAmount, coinsToAdd);
    }

    public override void SeekPlayer(float speed)
    {
        print("Blon");
        base.SeekPlayer(speed);
    }

    internal void OnDeath()
    {
        Instantiate(popvfx, transform.position, transform.rotation);
        SpawnChildren();
    }

    private void SpawnChildren()
    {
        if (children.Length <= 0) { return; }
        foreach (BloonType bloonType in children)
        {
            Instantiate(bloonType, transform.position, transform.rotation).name = bloonType.bloonName;
        }
    }
}
