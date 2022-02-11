using UnityEngine;
using UnityEngine.AI;

public class Bloon : MonoBehaviour
{
    private Coins coin;
    private Lives lives;
    private NavMeshAgent agent;
    private GameObject player;
    private bool isOn = true;

    public string bloonName = "";

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
        player = FindObjectOfType<Player>().gameObject;
        BloonHealth = GetComponent<BloonHealth>();

        agent.autoBraking = false;
    }

    public void OnPlayerHit(int amount)
    {
        lives = FindObjectOfType<Lives>();
        lives.TakeLives(amount);
        Destroy(gameObject);
    }

    public virtual void SeekPlayer(float speed)
    {
        if (isOn)
        {
            agent.speed = speed;
            agent.SetDestination(player.transform.position);
        }
    }

    public virtual void OnDamageTaken(int damageAmount, int coinsToAdd, GameObject other)
    {
        try
        {
            coin = FindObjectOfType<Coins>();
            coin.AddCoins(coinsToAdd);
        }
        catch
        {
            print("waht");
        }
        BloonHealth.TakeDamage(damageAmount, other);
    }
}
