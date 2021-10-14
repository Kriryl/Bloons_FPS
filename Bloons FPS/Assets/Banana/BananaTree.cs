using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaTree : MonoBehaviour
{
    public Banana banana;
    public Transform spawnLocation;

    public float spawnInterval = 20f;
    public float start = 20f;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnBanana), start, spawnInterval);
    }

    private void SpawnBanana()
    {
        Banana newBanana = Instantiate(banana, spawnLocation.position, Quaternion.identity);
    }
}
