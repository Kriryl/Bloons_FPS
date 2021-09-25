using UnityEngine;
using UnityEngine.AI;

public class Bloon : MonoBehaviour
{
    private NavMeshAgent agent;
    private GameObject player;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player");
    }

    public virtual void SeekPlayer(float speed)
    {
        agent.speed = speed;
        agent.SetDestination(player.transform.position);

    }
}
