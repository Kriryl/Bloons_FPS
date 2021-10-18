using UnityEngine;

public class Base : MonoBehaviour
{
    public Player player;

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    public virtual void OnUpgradeBought()
    {

    }
}
