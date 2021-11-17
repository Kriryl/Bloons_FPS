using System;
using UnityEngine;

public class WinController : MonoBehaviour
{
    public GameObject winCanvas;
    [NonSerialized]
    public bool hasWon = false;

    private void Update()
    {
        if (hasWon)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void Restart()
    {
        SceneLoader.RestartScene();
    }

    public void MainMenu()
    {
        Cursor.lockState = CursorLockMode.None;
        SceneLoader.PlayAgain();
    }

    internal void OnAllWavesComplete()
    {
        hasWon = true;
        winCanvas.SetActive(true);
    }
}
