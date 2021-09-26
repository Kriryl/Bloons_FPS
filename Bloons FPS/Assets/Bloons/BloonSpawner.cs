using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloonSpawner : MonoBehaviour
{
    public BloonType[] bloonPool;

    public float interval = 5f;
    public float startDelay = 2f;

    private int poolSize;

    private void Start()
    {
        poolSize = bloonPool.Length;
        InvokeRepeating(nameof(SpawnBloon), startDelay, interval);
    }

    private void SpawnBloon()
    {
        int randomNum = Random.Range(0, poolSize);
        _ = Instantiate(bloonPool[randomNum], transform.position, transform.rotation);
    }
}
