using UnityEditor.ProBuilder;
using UnityEngine;

public class BloonType : Bloon
{
    public BloonType[] children;
    public float speed = 5f;
    public bool On = true;
    public string bloonName = "Test Bloon";
    public int coinsOnDamage = 1;
    public int livesTakenOnHit = 1;
    public ParticleSystem popvfx;

    private void Update()
    {
        IsOn = On;
        SeekPlayer(speed);
    }

    private void OnParticleCollision(GameObject other)
    {
        Damage damage = other.GetComponentInParent<Damage>();
        if (damage)
        {
            OnDamageTaken(damage.damage, coinsOnDamage);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            OnPlayerHit(livesTakenOnHit);
        }
    }

    public override void OnDamageTaken(int damageAmount, int coinsToAdd)
    {
        base.OnDamageTaken(damageAmount, coinsToAdd);
    }

    public override void SeekPlayer(float speed)
    {
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
