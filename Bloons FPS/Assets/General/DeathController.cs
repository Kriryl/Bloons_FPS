using System.Collections;
using UnityEngine;

public class DeathController : MonoBehaviour
{
    public float delay = 2f;

    public void Restart()
    {
        _ = StartCoroutine(RestartScene());
    }

    private IEnumerator RestartScene()
    {
        yield return new WaitForSeconds(delay);
        SceneLoader.RestartScene();
    }
}
