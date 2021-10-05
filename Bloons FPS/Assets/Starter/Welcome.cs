using TMPro;
using UnityEngine;

public class Welcome : MonoBehaviour
{
    public GameObject hiddenGameObjects;
    public TextMeshProUGUI welcomeMessage;
    public TextMeshProUGUI rulesMessage;
    public TextMeshProUGUI rankText;
    public string gameName = "Bloons FPS";
    public float gameVersion = 1.0f;

    private void Start()
    {
        hiddenGameObjects.SetActive(false);
        welcomeMessage.text = $"Welcome to {gameName}!";
        rulesMessage.text = "Rules:" + " Bloons will spawn from the circular cubes called 'Spawner'." + " The bloons will chase you, dealing damage to you." + " If your health reaches zero, you die." + " You automaticly shoot in front of you." + " Some bloons have higher rank than others, these bloons move faster and will spawn their children on death; which are one rank bellow." + "";
        rankText.text = "Bloon ranks, first to last:" + " Red." + " Blue." + " Green." + " Yellow." + " Pink." + " Rainbow" + " Ceramic." + " MOAB" + "";
    }
}
