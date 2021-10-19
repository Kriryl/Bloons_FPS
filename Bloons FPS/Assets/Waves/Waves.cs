using System.Collections;
using System;
using UnityEngine;

public class Waves : MonoBehaviour
{
    public BloonSpawner spawner;
    public Wave[] waves;
    public float timeBetweenWaves = 5f;
    private int numOfBloons = int.MaxValue;
    private bool spawnWave = false;

    [Serializable]
    public class Wave
    {
        public float interval = 1f;
        public BloonType[] bloons;
    }

    private void Update()
    {
        numOfBloons = FindObjectsOfType<BloonType>().Length;
    }

    private void Start()
    {
        _ = StartCoroutine(SpawnAllWaves());
    }

    private IEnumerator SpawnAllWaves()
    {
        for (int i = 0; i < waves.Length; i++)
        {
            spawnWave = false;
            StartCoroutine(SpawnWave(waves[i]));
            yield return new WaitUntil(() => numOfBloons <= 0 && spawnWave);
        }
    }

    private IEnumerator SpawnWave(Wave wave)
    {
        for (int i = 0; i < wave.bloons.Length; i++)
        {
            spawner.SpawnBloon(wave.bloons[i]);
            yield return new WaitForSeconds(wave.interval);
        }
        spawnWave = true;
    }
}
