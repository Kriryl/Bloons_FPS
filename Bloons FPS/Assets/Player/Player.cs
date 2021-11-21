using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private List<ParticleSystem> projectiles = null;

    [Header("Projectile Properties")]
    [Tooltip("Damage of each projectile")] [SerializeField] private int damage = 1;
    [Tooltip("Number of projectiles per second")] [SerializeField] private float attackSpeed = 1f;
    [Tooltip("Start velocity of the projectile")] [SerializeField] private float shotSpeed = 30f;
    [Tooltip("Projectile Lifetime")] [SerializeField] private float range = 10f;
    [SerializeField] private float accuracy = 2f;
    [SerializeField] private float projectileRadius = 0.1f;
    [SerializeField] private float projectileSize = 0.2f;
    [SerializeField] private Mesh mesh;
    [SerializeField] private float bounce = 1f;
    [SerializeField] private float damp = 1f;
    [SerializeField] private float loss = 1f;
    [SerializeField] private LayerMask layerMask;

    private float nextTimeToFire = 0f;

    Damage damageObject;
    ParticleSystem mainProjectile;

    public ParticleSystem[] Projectiles => projectiles.ToArray();

    public int Damage
    {
        get => damage;
        set => damage = value;
    }
    public float AttackSpeed 
    { 
        get => attackSpeed; set => attackSpeed = value; 
    }
    public float ShotSpeed
    {
        get => shotSpeed; set => shotSpeed = value;
    }
    public float Range
    {
        get => range; set => range = value;
    }
    public float Accuracy
    {
        get => accuracy; set => accuracy = value;
    }
    public float ProjectileRadius
    {
        get => projectileRadius; set => projectileRadius = value;
    }
    public float ProjectileSize
    {
        get => projectileSize; set => projectileSize = value;
    }

    public Mesh Mesh
    {
        get => mesh; set => mesh = value;
    }

    public float Bounce
    {
        get => bounce; set => bounce = value;
    }

    public float Dampen
    {
        get => damp; set => damp = value;
    }

    public float Loss
    {
        get => loss; set => loss = value;
    }

    public LayerMask LayerMask
    {
        get => layerMask; set => layerMask = value;
    }

    private void Start()
    {
        damageObject = GetComponent<Damage>();
        mainProjectile = projectiles[0];
        foreach (ParticleSystem particleSystem in projectiles)
        {
            ParticleSystem.MainModule main = particleSystem.main;
            main.playOnAwake = false;
        }
    }

    private void Update()
    {
        FireIfReady();
        CalculateStats();
    }

    private void CalculateStats()
    {
        foreach (ParticleSystem projectile in projectiles)
        {
            damageObject.damage = damage;
            ShotSpeedAndRange();
            Accuracy();
            SetMesh();
            CollisionStuff();

            void ShotSpeedAndRange()
            {
                ParticleSystem.MainModule main = projectile.main;
                main.startSpeed = shotSpeed;
                main.startLifetime = range;
                main.startSize = projectileSize;
            }

            void Accuracy()
            {
                ParticleSystem.ShapeModule shapeModule = projectile.shape;
                shapeModule.radius = projectileRadius;
                shapeModule.angle = accuracy;
            }

            void SetMesh()
            {
                ParticleSystemRenderer particleSystemRenderer = projectile.GetComponent<ParticleSystemRenderer>();
                particleSystemRenderer.mesh = mesh;
            }

            void CollisionStuff()
            {
                var module = projectile.collision;
                module.bounce = bounce;
                module.dampen = damp;
                module.lifetimeLoss = loss;
                module.collidesWith = layerMask;
            }
        }
    }

    public void AddBullet(ParticleSystem projectile, Vector3 pos)
    {
        projectile.transform.parent = Camera.main.transform;
        projectile.transform.SetPositionAndRotation(Vector3.zero, new Quaternion(0, 0, 0, 0));
        projectile.transform.localPosition = mainProjectile.transform.localPosition + pos;
        projectiles.Add(projectile);
        foreach (ParticleSystem particleSystem in projectiles)
        {
            particleSystem.Stop();
        }
    }

    public void AddBullet(int num, Vector3 pos)
    {
        for (int i = 0; i < num; i++)
        {
            ParticleSystem projectile = Instantiate(projectiles[0]);
            projectile.transform.parent = Camera.main.transform;
            projectile.transform.SetPositionAndRotation(Vector3.zero, new Quaternion(0, 0, 0, 0));
            projectile.transform.localPosition = mainProjectile.transform.localPosition + pos;
            projectiles.Add(projectile);
            foreach (ParticleSystem particleSystem in projectiles)
            {
                particleSystem.Stop();
            }
        }
    }

    public void AddIndepententBullet(ParticleSystem projectiles, Vector3 pos)
    {
        ParticleSystem projectile = Instantiate(projectiles);
        projectile.transform.parent = Camera.main.transform;
        projectile.transform.SetPositionAndRotation(Vector3.zero, new Quaternion(0, 0, 0, 0));
        projectile.transform.localPosition = mainProjectile.transform.localPosition + pos;
    }

    public void AddIndepententBullet(GameObject projectiles, Vector3 pos)
    {
        GameObject projectile = Instantiate(projectiles);
        projectile.transform.parent = Camera.main.transform;
        projectile.transform.SetPositionAndRotation(Vector3.zero, new Quaternion(0, 0, 0, 0));
        projectile.transform.localPosition = mainProjectile.transform.localPosition + pos;
    }

    private void FireProjectile()
    {
        foreach (ParticleSystem particleSystem in projectiles)
        {
            particleSystem.Emit(1);
        }
    }

    private void FireIfReady()
    {
        if (Input.GetMouseButton(0) && Time.time >= nextTimeToFire)
        {
            if (attackSpeed <= 0) { return; }
            nextTimeToFire = Time.time + (1f / attackSpeed);
            FireProjectile();
        }
    }

    public void IncreaseStats(int damage, float attackSpeed, float shotSpeed, float projectileRadius, float accuracy, float range)
    {
        this.damage += damage;
        this.attackSpeed += attackSpeed;
        this.shotSpeed += shotSpeed;
        this.range += range;
        if (this.projectileRadius + projectileRadius >= 0)
        {
            this.projectileRadius += projectileRadius;
        }
        else
        {
            this.projectileRadius = 0.001f;
        }
        if (this.accuracy + accuracy < 0)
        {
            this.accuracy = 0;
            return;
        }
        this.accuracy += accuracy;
    }
}

// 91538206