using UnityEngine.UI;
using UnityEngine;

public class MainMenuSelect : MonoBehaviour
{
    public Image image;

    public bool IsChosen { get; set; }

    public void OnClick()
    {
        foreach (MainMenuSelect mainMenuSelect in FindObjectsOfType<MainMenuSelect>())
        {
            mainMenuSelect.IsChosen = false;
        }
        IsChosen = true;
        foreach (MainMenuSelect mainMenuSelect in FindObjectsOfType<MainMenuSelect>())
        {
            mainMenuSelect.Display();
        }
    }

    private void Display()
    {
        image.color = IsChosen ? Color.green : Color.white;
    }
}
