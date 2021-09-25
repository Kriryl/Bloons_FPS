using UnityEngine;
using UnityEngine.AI;

public class Bloon : MonoBehaviour
{
    private NavMeshAgent agent;
    private GameObject player;
    private BloonHealth health;

    public int Health => health.health;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player");
        health = GetComponent<BloonHealth>();
    }

    public virtual void SeekPlayer(float speed)
    {
        agent.speed = speed;
        agent.SetDestination(player.transform.position);
    }

    public virtual void OnDamageTaken(int damageAmount)
    {
        health.TakeDamage(damageAmount);
    }
}
