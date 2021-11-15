using System.Collections;
using System;
using UnityEngine;
using TMPro;

public class Waves : MonoBehaviour
{
    public BloonSpawner spawner;
    public TextMeshProUGUI waveDisplay;
    public Wave[] waves;
    public float rewardMoney = 10f;
    public float rewardIncrease = 1f;
    public float delay = 0f;

    private int numOfBloons = int.MaxValue;
    private bool spawnWave = false;
    private int maxWave;
    private Coins coins;

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
        maxWave = waves.Length;
        coins = FindObjectOfType<Coins>();
        Invoke(nameof(StartWaves), delay);
    }

    private void StartWaves()
    {
        _ = StartCoroutine(SpawnAllWaves());
    }

    private IEnumerator SpawnAllWaves()
    {
        for (int i = 0; i < waves.Length; i++)
        {
            spawnWave = false;
            DisplayWave(i);
            StartCoroutine(SpawnWave(waves[i]));
            yield return new WaitUntil(() => numOfBloons <= 0 && spawnWave);
            GlobalEventManager.CallEvent("OnWaveComplete");
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
            coins.AddCoins(rewardMoney);
            rewardMoney += rewardIncrease;
        }
    }
}
