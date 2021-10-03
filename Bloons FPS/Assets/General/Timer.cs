using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timeText;

    private void Update()
    {
        float realTime = Time.timeSinceLevelLoad;
        float smoothTime = Mathf.Round(realTime * 100f) / 100f;
        timeText.text = smoothTime.ToString();
    }
}
