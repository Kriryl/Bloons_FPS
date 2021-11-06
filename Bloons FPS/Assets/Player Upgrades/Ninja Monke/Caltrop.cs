using UnityEngine;

public class Caltrop : MonoBehaviour
{
    public int maxHits = 3;
    private int currentHits = 0;
    public float lifeSpan = 10f;
    private float currentLifeTime = 0f;
    private float lifeFrames;

    private void Start()
    {
        lifeFrames = lifeSpan * 50f;
    }

    private void FixedUpdate()
    {
        if (currentLifeTime > lifeFrames)
        {
            Destroy(gameObject);
        }
        currentLifeTime++;
    }

    private void Update()
    {
        if (currentHits >= maxHits)
        {
            Destroy(gameObject);
        }

        transform.rotation = new Quaternion(0f, 180f, 0f, 0f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }
        if (collision.gameObject.GetComponent<BloonType>())
        {
            currentHits++;
        }
    }
}
