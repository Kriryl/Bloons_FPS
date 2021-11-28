using UnityEngine;

public class Base : MonoBehaviour
{
    [HideInInspector]
    public Player player;
    [HideInInspector]
    public bool isActive = false;

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    public virtual void OnUpgradeBought()
    {
        isActive = true;
        player = FindObjectOfType<Player>();
    }

    public virtual void OnSupportUpgradeBought()
    {
        isActive = true;
        player = FindObjectOfType<Player>();
    }

    public bool AlreadyBought()
    {
        return enabled && !isActive;
    }
}

//public override void OnUpgradeBought()
//{
//    if (!AlreadyBought()) { return; }
//    base.OnUpgradeBought();


//}