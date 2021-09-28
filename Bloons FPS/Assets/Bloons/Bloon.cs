using UnityEngine;
using UnityEngine.AI;

public class Bloon : MonoBehaviour
{
    private Coins coin;
    private Lives lives;
    private NavMeshAgent agent;
    private GameObject player;
    private bool isOn = true;

    public int Health => BloonHealth.health;

    public BloonHealth BloonHealth { get; set; }

    public bool IsOn
    {
        get => isOn;
        set => isOn = value;
    }

    

    private void Start()
    {
        coin = FindObjectOfType<Coins>();
        lives = FindObjectOfType<Lives>();
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player");
        BloonHealth = GetComponent<BloonHealth>();
    }

    public void OnPlayerHit(int amount)
    {
        lives.TakeLives(amount);
    }

    public virtual void SeekPlayer(float speed)
    {
        if (isOn)
        {
            agent.speed = speed;
            agent.SetDestination(player.transform.position);
        }
    }

    public virtual void OnDamageTaken(int damageAmount, int coinsToAdd)
    {
        try
        {
            coin.AddCoins(coinsToAdd);
        }
        catch
        {
            print("waht");
        }
        BloonHealth.TakeDamage(damageAmount);
    }
}
