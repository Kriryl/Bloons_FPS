using UnityEngine;

public class Base : MonoBehaviour
{
    [HideInInspector]
    public Player player;
    public bool isActive = false;

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    public virtual void OnUpgradeBought()
    {
        isActive = true;
    }

    public bool IsActive()
    {
        return enabled && !isActive;
    }
}
