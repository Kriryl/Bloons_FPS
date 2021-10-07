using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Welcome : MonoBehaviour
{
    public GameObject hiddenGameObjects;
    public TextMeshProUGUI welcomeMessage;
    public TextMeshProUGUI rulesMessage;
    public TextMeshProUGUI rankText;
    public TextMeshProUGUI loadingText;
    public string gameName = "Bloons FPS";
    public float gameVersion = 1.0f;

    bool loading = false;
    float loadingProcces = 0f;

    private void Start()
    {
        loading = false;
        hiddenGameObjects.SetActive(false);
        welcomeMessage.text = $"Welcome to {gameName}!";
        rulesMessage.text = "Rules:" + " Bloons will spawn from the circular cubes called 'Spawner'." + " The bloons will chase you, dealing damage to you." + " If your health reaches zero, you die." + " You automaticly shoot in front of you." + " Some bloons have higher rank than others, these bloons move faster and will spawn their children on death; which are one rank bellow." + "";
        rankText.text = "Bloon ranks, first to last:" + " Red." + " Blue." + " Green." + " Yellow." + " Pink." + " Rainbow" + " Ceramic." + " MOAB" + "";
    }

    private void Update()
    {
        if (loading)
        {
            loadingText.text = $"{loadingProcces}%";
            
        }
    }

    internal void OnDifficultySelect()
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        loadingProcces = asyncOperation.progress;
        asyncOperation.allowSceneActivation = true;
    }
}
