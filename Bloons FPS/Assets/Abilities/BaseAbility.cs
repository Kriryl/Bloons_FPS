using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BaseAbility : MonoBehaviour
{
    public const KeyCode ACTIVATE_ABILITY_KEY = KeyCode.F;

    public Image fillImage;
    public Slider cooldownSlider;

    public float baseDuration = 5f;
    public float baseCooldown = 30f;
    private float currentCooldown = 0f;
    private bool abilityActive = false;
    private bool canUse = false;
    private float cooldownFrames;

    private void Start()
    {
        cooldownFrames = baseCooldown * 50f;
        cooldownSlider.minValue = 0f;
        cooldownSlider.maxValue = cooldownFrames;
    }

    private void FixedUpdate()
    {
        if (!abilityActive && !canUse)
        {
            currentCooldown++;
            if (currentCooldown >= cooldownFrames)
            {
                canUse = true;
            }
        }

        DisplayAbility();
    }

    private void Update()
    {
        if (Input.GetKeyDown(ACTIVATE_ABILITY_KEY))
        {
            if (canUse && !abilityActive)
            {
                BroadcastMessage("OnActivate");
            }
        }
    }

    private void DisplayAbility()
    {
        cooldownSlider.value = currentCooldown;
        fillImage.enabled = !abilityActive;
    }

    public virtual void OnAbilityEnd()
    {
    }

    public virtual void OnActivate()
    {
        currentCooldown = 0f;
        abilityActive = true;
        print("ability active");
        StartCoroutine(WaitForAbilityEnd());
    }

    private IEnumerator WaitForAbilityEnd()
    {
        yield return new WaitForSeconds(baseDuration);
        abilityActive = false;
        canUse = false;
        print("ability ended");
        BroadcastMessage("OnAbilityEnd");
    }
}
