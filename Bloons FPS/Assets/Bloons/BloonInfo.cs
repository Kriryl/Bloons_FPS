using UnityEngine;

public class BloonInfo : MonoBehaviour
{
    public const float RED_BLOON_SPEED = 2f;

    // Normal bloons
    public const float BLUE_BLOON_SPEED = RED_BLOON_SPEED * 1.4f;
    public const float GREEN_BLOON_SPEED = RED_BLOON_SPEED * 1.8f;
    public const float YELLOW_BLOON_SPEED = RED_BLOON_SPEED * 3.2f;
    public const float PINK_BLOON_SPEED = RED_BLOON_SPEED * 3.5f;

    // Special bloons
    public const float RAINBOW_BLOON_SPEED = RED_BLOON_SPEED * 2.2f;
    public const float CERAMIC_BLOON_SPEED = RED_BLOON_SPEED * 2.5f;

    private void OnBloonSpawn(BloonType bloonType)
    {
        string lower = bloonType.bloonName.ToLower();
        switch (lower)
        {
            case "red bloon":
                bloonType.speed = RED_BLOON_SPEED;
                break;
            case "blue bloon":
                bloonType.speed = BLUE_BLOON_SPEED;
                break;
            case "green bloon":
                bloonType.speed = GREEN_BLOON_SPEED;
                break;
            case "yellow bloon":
                bloonType.speed = YELLOW_BLOON_SPEED;
                break;
            case "pink bloon":
                bloonType.speed = PINK_BLOON_SPEED;
                break;
            case "rainbow bloon":
                bloonType.speed = RAINBOW_BLOON_SPEED;
                break;
            case "ceramic bloon":
                bloonType.speed = CERAMIC_BLOON_SPEED;
                break;
            default:
                print("Could not find speed based on name");
                break;
        }
    }
}
