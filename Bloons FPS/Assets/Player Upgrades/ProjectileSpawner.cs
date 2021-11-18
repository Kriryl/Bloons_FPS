using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    public GameObject projectileToSpawn;
    public float spawnRate = 1.5f;
    public float velocity = 5f;

    private void Start()
    {
        StartCoroutine(SpawnProjectile());
    }

    private IEnumerator SpawnProjectile()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            GameObject newProjectile = Instantiate(projectileToSpawn, transform.position, transform.rotation);
            Rigidbody rb = newProjectile.GetComponent<Rigidbody>();
            if (rb)
            {
                rb.AddRelativeForce(Vector3.forward * velocity);
            }
        }
    }
}
