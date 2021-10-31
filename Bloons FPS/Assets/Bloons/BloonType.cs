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
    [HideInInspector()]
    public int damageLeft = 0;
    public bool affectsChildren = true;

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
        BloonHealth = GetComponent<BloonHealth>();
        if (damageAmount > BloonHealth.health)
        {
            damageLeft = damageAmount - Health;
        }
        base.OnDamageTaken(damageAmount, damageAmount);
    }

    public override void SeekPlayer(float speed)
    {
        base.SeekPlayer(speed);
    }

    internal void OnDeath()
    {
        if (damageLeft > 0 && affectsChildren)
        {
            for (int i = damageLeft; i > 0; i--)
            {
                OverKill();
            }
        }
        GameObject pop = Instantiate(popvfx, transform.position, transform.rotation).gameObject;
        Destroy(pop, 1f);
        SpawnChildren();
    }

    private void OverKill()
    {
        for (int i = 0; i < children.Length; i++)
        {
            if (children.Length > 0)
            {
                BloonType bloonType = children[i];
                if (bloonType.children.Length > 0)
                {
                    for (int child = 0; child < bloonType.children.Length; child++)
                    {
                        children[i] = bloonType.children[child];
                    }
                }
                else
                {
                    if (children[i] != null)
                    {
                        Destroy(children[i].gameObject);
                    }
                    Destroy(gameObject);
                }
            }
        }
    }

    private void SpawnChildren()
    {
        foreach (BloonType bloonType in children)
        {
            if (bloonType != null)
            {
                bloonType.transform.parent = null;
                bloonType.gameObject.layer = LayerMask.NameToLayer("Bloon");
                bloonType.gameObject.SetActive(true);
            }
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