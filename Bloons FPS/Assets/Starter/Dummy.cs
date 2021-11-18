using UnityEngine.AI;
using UnityEngine;

public class Dummy : MonoBehaviour
{
    public Vector3 destination;
    private NavMeshAgent meshAgent;
    [HideInInspector]
    public float speed = 2f;
    private float time = 0f;

    private void Start()
    {
        meshAgent = GetComponent<NavMeshAgent>();
        meshAgent.SetDestination(destination);
    }

    private void Update()
    {
        meshAgent.speed = speed;
    }

    private void FixedUpdate()
    {
        time++;
        if (time * 50 > 4 * 50)
        {
            if (meshAgent.velocity == Vector3.zero)
            {
                Destroy(gameObject);
            }
        }
    }
}
