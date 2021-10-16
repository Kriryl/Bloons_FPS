using System.Collections;
using System;
using UnityEngine;

public class Waves : MonoBehaviour
{
    public BloonSpawner spawner;
    public Wave[] waves;
    public float timeBetweenWaves = 5f;

    [Serializable]
    public class Wave
    {
        public float interval = 1f;
        public BloonType[] bloons;
    }

    private void Start()
    {
        _ = StartCoroutine(SpawnAllWaves());
    }

    private IEnumerator SpawnAllWaves()
    {
        for (int i = 0; i < waves.Length; i++)
        {
            SpawnWave(waves[i]);
            yield return new WaitForSeconds(timeBetweenWaves);
        }
        print("All waves spawned");
    }

    private IEnumerator SpawnWave(Wave wave)
    {
        for (int i = 0; i < wave.bloons.Length; i++)
        {
            spawner.SpawnBloon(wave.bloons[i]);
            yield return new WaitForSeconds(wave.interval);
        }
        print("Wave spawned");
    }
}
