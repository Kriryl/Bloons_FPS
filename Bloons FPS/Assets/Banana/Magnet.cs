using UnityEngine;

public class Magnet : MonoBehaviour
{
    public float radius = 3.5f;
    public float force = 1f;

    Player player;

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    private void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= radius)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, force);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
