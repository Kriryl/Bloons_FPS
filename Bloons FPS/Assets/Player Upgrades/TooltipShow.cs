using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class TooltipShow : MonoBehaviour
{
    public Image canvas;
    public TextMeshProUGUI tooltipText;
    public bool showTooltip = false;
    public Vector3 addedPos = Vector3.zero;

    public string tooltip = "";

    private void Start()
    {
        Hide();
    }

    public Vector3 GetMousePos()
    {
        return Input.mousePosition + addedPos;
    }

    public void Show()
    {
        canvas.gameObject.SetActive(true);
        tooltipText.text = tooltip;
    }

    public void Hide()
    {
        canvas.gameObject.SetActive(false);
    }
}
