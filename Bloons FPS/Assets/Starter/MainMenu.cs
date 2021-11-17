using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject notice;

    public void CloseNotice()
    {
        notice.SetActive(false);
    }

    public void PlayGame()
    {
        SceneLoader.LoadNextScene();
    }
}
