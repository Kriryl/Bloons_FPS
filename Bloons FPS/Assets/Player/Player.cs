using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private ParticleSystem projectile = null;

    [Header("Projectile Properties")]
    [Tooltip("Damage of each projectile")] [SerializeField] private int damage = 1;
    [Tooltip("Number of projectiles per second")] [SerializeField] private float attackSpeed = 1f;
    [Tooltip("Start velocity of the projectile")] [SerializeField] private float shotSpeed = 30f;
    [Tooltip("Not in use yet...")] [SerializeField] private float range = 10f;

    Damage damageObject;

    public int Damage => damage;
    public float AttackSpeed => attackSpeed;
    public float ShotSpeed => shotSpeed;
    public float Range => range;

    private void Start()
    {
        damageObject = GetComponent<Damage>();
    }

    private void Update()
    {
        CalculateStats();
    }

    private void CalculateStats()
    {
        damageObject.damage = damage;
        ShotSpeed();
        AttackSpeed();

        void ShotSpeed()
        {
            ParticleSystem.MainModule main = projectile.main;
            main.startSpeed = shotSpeed;
        }

        void AttackSpeed()
        {
            ParticleSystem.EmissionModule emission = projectile.emission;
            emission.rateOverTime = new ParticleSystem.MinMaxCurve(attackSpeed);
        }
    }

    public void ApplyStats(int damage, float attackSpeed, float shotSpeed)
    {
        this.damage = damage;
        this.attackSpeed = attackSpeed;
        this.shotSpeed = shotSpeed;
    }
}
