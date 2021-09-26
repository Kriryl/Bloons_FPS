using UnityEngine;
using TMPro;

public class Shop : MonoBehaviour
{
    public const KeyCode INTERACT = KeyCode.E;
    public int buyIndex = 0;
    public float interactDistance = 3f;

    public TextMeshProUGUI interactText;

    Upgrades upgrades;
    Player player;

    private float distanceFromPlayer = float.MaxValue;

    private void Start()
    {
        upgrades = FindObjectOfType<Upgrades>();
        player = FindObjectOfType<Player>();
        interactText.enabled = false;
    }

    private void Update()
    {
        distanceFromPlayer = Vector3.Distance(player.transform.position, transform.position);
        if (distanceFromPlayer <= interactDistance)
        {
            interactText.enabled = true;
            if (Input.GetKeyDown(INTERACT))
            {
                BuyItem();
            }
        }
        else
        {
            interactText.enabled = false;
        }
    }

    private void BuyItem()
    {
        if (upgrades.CheckCost(buyIndex))
        {
            buyIndex++;
        }
    }
}
