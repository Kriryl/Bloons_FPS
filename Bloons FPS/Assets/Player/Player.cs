using System.Collections;
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

    Damage damageObject;
    ParticleSystem mainProjectile;

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

    private void Start()
    {
        damageObject = GetComponent<Damage>();
        mainProjectile = projectiles[0];
    }

    private void Update()
    {
        CalculateStats();
    }

    private void CalculateStats()
    {
        foreach (ParticleSystem projectile in projectiles)
        {
            damageObject.damage = damage;
            ShotSpeedAndRange();
            AttackSpeed();
            Accuracy();

            void ShotSpeedAndRange()
            {
                ParticleSystem.MainModule main = projectile.main;
                main.startSpeed = shotSpeed;
                main.startLifetime = range;
            }

            void AttackSpeed()
            {
                ParticleSystem.EmissionModule emission = projectile.emission;
                emission.rateOverTime = new ParticleSystem.MinMaxCurve(attackSpeed);
            }

            void Accuracy()
            {
                ParticleSystem.ShapeModule shapeModule = projectile.shape;
                shapeModule.radius = projectileRadius;
                shapeModule.angle = accuracy;
            }
        }
    }

    public void AddBullet(ParticleSystem projectile, Vector3 pos)
    {
        projectile.transform.parent = Camera.main.transform;
        projectile.transform.position = Vector3.zero;
        projectile.transform.rotation = new Quaternion(0, 0, 0, 0);
        projectile.transform.localPosition = mainProjectile.transform.localPosition + pos;
        projectiles.Add(projectile);
        foreach(ParticleSystem particleSystem in projectiles)
        {
            particleSystem.Stop();
            particleSystem.Play();
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
