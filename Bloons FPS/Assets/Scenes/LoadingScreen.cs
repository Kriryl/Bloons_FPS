using System.Collections;
using UnityEngine;
using TMPro;

public class LoadingScreen : MonoBehaviour
{
    public TextMeshProUGUI text;
    public float loadingTime = 4f;
    public bool async = true;

    private void Start()
    {
        _ = StartCoroutine(Load());
        _ = StartCoroutine(Animate());
        
    }

    private IEnumerator Animate()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.3f);
            text.text = "Loading";
            yield return new WaitForSeconds(0.3f);
            text.text = "Loading.";
            yield return new WaitForSeconds(0.3f);
            text.text = "Loading..";
            yield return new WaitForSeconds(0.3f);
            text.text = "Loading...";
        }
    }

    private IEnumerator Load()
    {
        AsyncOperation asyncOperation = SceneLoader.GetAsync(SceneLoader.GetCurrentScene() + 1);
        asyncOperation.allowSceneActivation = false;
        yield return new WaitForSeconds(loadingTime);
        asyncOperation.allowSceneActivation = true;
    }
}
