using UnityEngine;
using UnityEngine.AI;

public class Bloon : MonoBehaviour
{
    private NavMeshAgent agent;
    private GameObject player;
    private BloonHealth health;
    private bool isOn = true;

    public int Health => health.health;

    public bool IsOn
    {
        get => isOn;
        set => isOn = value;
    }

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player");
        health = GetComponent<BloonHealth>();
    }

    public virtual void SeekPlayer(float speed)
    {
        if (isOn)
        {
            agent.speed = speed;
            agent.SetDestination(player.transform.position);
        }
    }

    public virtual void OnDamageTaken(int damageAmount)
    {
        health.TakeDamage(damageAmount);
    }
}
