using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaTree : MonoBehaviour
{
    public Banana banana;
    public Transform spawnLocation;

    public float spawnInterval = 20f;
    public float start = 20f;
    public float treeValue = 20f;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnBanana), start, spawnInterval);
    }

    private void SpawnBanana()
    {
        Banana newBanana = Instantiate(banana, spawnLocation.position, Quaternion.identity);
        newBanana.bananaWorth = treeValue;
    }

    public void IncreaseStats(float spawnRate, float value)
    {
        spawnInterval += spawnRate;
        treeValue += value;
    }
}
