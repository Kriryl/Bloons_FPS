using UnityEngine;
using TMPro;

public class Shop : MonoBehaviour
{
    public const KeyCode INTERACT = KeyCode.E;
    public float interactDistance = 3f;
    public bool isOpen = false;

    public TextMeshProUGUI interactText;
    public Canvas shopCanvas;

    Player player;

    private float distanceFromPlayer = float.MaxValue;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        interactText.enabled = false;
        shopCanvas.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (!isOpen)
        {
            distanceFromPlayer = Vector3.Distance(player.transform.position, transform.position);
            if (distanceFromPlayer <= interactDistance)
            {
                interactText.enabled = true;
                if (Input.GetKeyDown(INTERACT))
                {
                    OpenShop();
                }
            }
            else
            {
                interactText.enabled = false;
            }
        }
        else if (isOpen)
        {
            if (Input.GetKeyDown(INTERACT))
            {
                Cursor.lockState = CursorLockMode.Locked;
                isOpen = false;
                shopCanvas.gameObject.SetActive(false);
                Cursor.visible = false;
                Time.timeScale = 1f;
            }
        }
    }

    private void OpenShop()
    {
        isOpen = true;
        shopCanvas.gameObject.SetActive(true);
        interactText.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
    }
}
