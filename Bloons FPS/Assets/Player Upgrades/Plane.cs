using UnityEngine;

public class Plane : MonoBehaviour
{
    public Vector3[] wayPoints;
    public float speed = 2f;
    public bool hasStopped = false;
    public float reachLenght = 5f;

    [SerializeField] private Vector3 currentWaypoint;
    [SerializeField] private int wayPointInt = 0;

    private void Start()
    {
        currentWaypoint = wayPoints[0];
    }

    private void Update()
    {
        bool waypointReached = Vector3.Distance(transform.position, currentWaypoint) <= reachLenght;

        if (waypointReached)
        {
            wayPointInt++;

            if (wayPointInt > wayPoints.Length - 1)
            {
                currentWaypoint = wayPoints[0];
                wayPointInt = 0;
            }
            else
            {
                try
                {
                    currentWaypoint = wayPoints[wayPointInt];
                }
                catch
                {
                    print($"Waypoint {wayPointInt} is out of range. Max number: {wayPoints.Length - 1}");
                }
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, currentWaypoint, speed * Time.deltaTime);

        transform.LookAt(currentWaypoint);
    }
}
