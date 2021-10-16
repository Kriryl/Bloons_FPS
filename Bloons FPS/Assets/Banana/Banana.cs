using UnityEngine;
using UnityEngine.ProBuilder;
public class Banana : MonoBehaviour
{
    public float bananaWorth = 20;
    Coins coins;
    Rigidbody rb;
    Collider myCollider;

    private void Start()
    {
        coins = FindObjectOfType<Coins>();
        rb = GetComponent<Rigidbody>();
        myCollider = GetComponent<Collider>();
        rb.useGravity = true;
        myCollider.isTrigger = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        CheckForPlayer(other);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            rb.useGravity = false;
            rb.isKinematic = true;
            myCollider.isTrigger = true;
        }
    }

    private void CheckForPlayer(Collider other)
    {
        Player player = other.gameObject.GetComponent<Player>();
        if (player)
        {
            coins.AddCoins(bananaWorth);
            Destroy(gameObject);
        }
    }
}
