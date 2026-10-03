using UnityEngine;

public class StitchComponent : MonoBehaviour
{
    [Tooltip("The order index when this stitch should activate (e.g., 0, 1, 2...)")]
    public int executionOrder;

    // References to your actual gameplay scripts
    [Header("Mechanic Scripts")]
    public MonoBehaviour movingPlatformScript;
    public MonoBehaviour holdSliderScript;

    // Activates or deactivates the mechanics on this object
    public void SetStitchActive(bool isActive)
    {
        if (movingPlatformScript != null) movingPlatformScript.enabled = isActive;
        if (holdSliderScript != null) holdSliderScript.enabled = isActive;

        Debug.Log($"{gameObject.name} (Order {executionOrder}) set to: {isActive}");
    }
}
