using System.Collections;
using System;
using UnityEngine;
using TMPro;

public class Waves : MonoBehaviour
{
    public BloonSpawner spawner;
    public TextMeshProUGUI waveDisplay;
    public Wave[] waves;
    private int numOfBloons = int.MaxValue;
    private bool spawnWave = false;
    private int maxWave;
    private Coins coins;
    private float rewardMoney;

    [Serializable]
    public class Wave
    {
        public float interval = 1f;
        public BloonType[] bloons;
        public float rewardMoney = 10f;
    }

    private void Update()
    {
        numOfBloons = FindObjectsOfType<BloonType>().Length;
    }

    private void Start()
    {
        maxWave = waves.Length;
        coins = FindObjectOfType<Coins>();
        _ = StartCoroutine(SpawnAllWaves());
    }

    private IEnumerator SpawnAllWaves()
    {
        for (int i = 0; i < waves.Length; i++)
        {
            rewardMoney = waves[i].rewardMoney;
            spawnWave = false;
            DisplayWave(i);
            StartCoroutine(SpawnWave(waves[i]));
            yield return new WaitUntil(() => numOfBloons <= 0 && spawnWave);
            RewardPlayer();
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

    private void DisplayWave(int index)
    {
        waveDisplay.text = $"Wave {index + 1}/{maxWave}";
    }

    private void RewardPlayer()
    {
        if (coins)
        {
            print($"Round complete. Player rewarded ${rewardMoney} coins");
            coins.AddCoins(rewardMoney);
        }
    }
}
