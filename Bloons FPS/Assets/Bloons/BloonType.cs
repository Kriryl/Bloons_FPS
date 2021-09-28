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
    public int damageLeft = 0;

    private void Update()
    {
        IsOn = On;
        SeekPlayer(speed);
    }

    private void OnEnable()
    {
        BloonHealth = GetComponent<BloonHealth>();
        print(BloonHealth);
        BloonHealth.TakeDamage(damageLeft);
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
        if (Health <= damageAmount)
        {
            foreach (BloonType bloonType in children)
            {
                bloonType.TakeOverDamage(damageAmount - Health);
            }
        }
        base.OnDamageTaken(damageAmount, coinsToAdd);
    }

    public override void SeekPlayer(float speed)
    {
        base.SeekPlayer(speed);
    }

    public void TakeOverDamage(int damage)
    {
        damageLeft = damage;
    }

    internal void OnDeath()
    {
        GameObject pop = Instantiate(popvfx, transform.position, transform.rotation).gameObject;
        Destroy(pop, 1f);
        SpawnChildren();
    }

    private void SpawnChildren()
    {
        foreach (BloonType bloonType in children)
        {
            bloonType.transform.parent = null;
            bloonType.gameObject.SetActive(true);
        }
        Destroy(gameObject);
    }
}

// Bloon Types:
// Red
// Blue
// Green
// Yellow
// Pink