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
    public float hardCap = 1f;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(start);
        _ = StartCoroutine(SpawnBanana());
    }

    private IEnumerator SpawnBanana()
    {
        while (true)
        {
            if (hardCap == Mathf.Epsilon) { break; }
            Banana newBanana = Instantiate(banana, spawnLocation.position, Quaternion.identity);
            newBanana.bananaWorth = treeValue;
            if (spawnInterval < hardCap) { spawnInterval = hardCap; }
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    public void IncreaseStats(float spawnRate, float value)
    {
        spawnInterval -= spawnRate;
        if (spawnInterval < hardCap) { spawnInterval = hardCap; }
        treeValue += value;
    }
}
