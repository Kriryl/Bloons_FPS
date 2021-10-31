using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloonSpawner : MonoBehaviour
{
    public BloonType[] bloonPool;

    public float interval = 5f;
    public float startDelay = 2f;
    public float rampPace = 1f;
    public float rampStart = 60f;
    public bool hasRamped = false;
    public bool isOn = true;

    private int poolSize;

    private void Start()
    {
        poolSize = bloonPool.Length;
        if (!isOn) { return; }
        InvokeRepeating(nameof(SpawnBloon), startDelay, interval);
    }

    private void Update()
    {
        if (!isOn) { return; }
        if (hasRamped) { return; }
        if (Time.timeSinceLevelLoad >= rampStart)
        {
            StartCoroutine(Ramp());
        }
    }

    private void SpawnBloon()
    {
        int randomNum = Random.Range(0, poolSize);
        _ = Instantiate(bloonPool[randomNum], transform.position, transform.rotation);
    }

    public void SpawnBloon(BloonType bloon)
    {
        BloonType bloonType = Instantiate(bloon, transform.position, transform.rotation);
        bloonType.gameObject.layer = LayerMask.NameToLayer("Bloon");
    }

    private IEnumerator Ramp()
    {
        hasRamped = true;
        CancelInvoke();
        while (interval > 1f)
        {
            SpawnBloon();
            interval *= 0.99f;
            yield return new WaitForSeconds(interval);
        }
    }
}
