using UnityEngine;

public class BloonType : Bloon
{
    public BloonType[] children;
    public float speed = 5f;
    public bool On = true;
    public int coinsOnDamage = 1;
    public int livesTakenOnHit = 1;
    public ParticleSystem popvfx;
    [HideInInspector()]
    public int damageLeft = 0;
    public bool affectsChildren = true;
    private float startSpeed;

    public bool IsFrozen { get; private set; } = false;

    public string Name => bloonName;

    public float Speed { get => speed; set => speed = value; }

    public float StartingSpeed => startSpeed;

    private void Update()
    {
        IsOn = On;
        SeekPlayer(speed);
    }

    public void SetNormalSpeed()
    {
        speed = startSpeed;
    }

    public void Freeze()
    {
        IsFrozen = true;
        speed = 0f;
    }

    public void Unfreeze()
    {
        SetNormalSpeed();
        IsFrozen = false;
    }

    private void OnEnable()
    {
        GlobalEventManager.CallEvent("OnBloonSpawn", this);
        startSpeed = speed;

    }

    public static BloonType[] GetAllBloons()
    {
        return FindObjectsOfType<BloonType>();
    }

    private void OnParticleCollision(GameObject other)
    {
        Damage damage = other.GetComponentInParent<Damage>();
        if (damage)
        {
            OnDamageTaken(damage.damage, coinsOnDamage, other);
        }
        else
        {
            damage = other.GetComponent<Damage>();
            if (damage)
            {
                OnDamageTaken(damage.damage, coinsOnDamage, other);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            OnPlayerHit(livesTakenOnHit);
        }
        else if (collision.gameObject.layer == LayerMask.NameToLayer("PlayerSpawned"))
        {
            Damage damage = collision.gameObject.GetComponent<Damage>();
            if (damage)
            {
                OnDamageTaken(damage.damage, coinsOnDamage, collision.gameObject);
            }
        }
    }

    public override void OnDamageTaken(int damageAmount, int coinsToAdd, GameObject other)
    {
        BloonHealth = GetComponent<BloonHealth>();
        if (damageAmount > BloonHealth.health)
        {
            damageLeft = damageAmount - Health;
        }
        base.OnDamageTaken(damageAmount, damageAmount, other);
    }

    public override void SeekPlayer(float speed)
    {
        base.SeekPlayer(speed);
    }

    internal void OnDeath(GameObject other)
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
        SpawnChildren(other);
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

    private void SpawnChildren(GameObject other)
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

        GlobalEventManager.EventInfo eventInfo = new GlobalEventManager.EventInfo(children, other);

        GlobalEventManager.CallEvent("OnBloonDeath", eventInfo);
        Destroy(gameObject);
    }
}

// Bloon Types:
// Red
// Blue
// Green
// Yellow
// Pink