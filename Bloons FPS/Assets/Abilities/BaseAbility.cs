using UnityEngine;

public class BaseAbility : MonoBehaviour
{
    public const KeyCode ACTIVATE_ABILITY_KEY = KeyCode.F;

    public float baseDuration = 5f;
    public float baseCooldown = 30f;
    private float currentCooldown = 0f;
    private bool abilityActive = false;
    private bool canUse = true;

    private void FixedUpdate()
    {
        if (!abilityActive && !canUse)
        {
            currentCooldown++;
            if (currentCooldown >= baseCooldown)
            {
                canUse = true;
                currentCooldown = 0f;
            }
        }

        if (Input.GetKeyDown(ACTIVATE_ABILITY_KEY))
        {
            BroadcastMessage("OnActivate");
        }
    }

    public virtual void OnActivate()
    {
        abilityActive = true;
    }
}
