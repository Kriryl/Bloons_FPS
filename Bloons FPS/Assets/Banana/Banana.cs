using UnityEngine;

public class Banana : MonoBehaviour
{
    public int bananaWorth = 20;
    Coins coins;

    private void Start()
    {
        coins = FindObjectOfType<Coins>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.gameObject.GetComponent<Player>();
        if (player)
        {
            coins.AddCoins(bananaWorth);
            Destroy(gameObject);
        }
    }
}
