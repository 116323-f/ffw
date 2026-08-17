using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class PressHoldRelease : MonoBehaviour
{
    InputAction XPressHoldRelease;
    private bool PointerEntered = false;
    //[SerializeField] private GameObject Press;
    [SerializeField] private SpriteRenderer Hold;
    [SerializeField] private SpriteRenderer Release;
    [SerializeField] private InputActionReference actionReference;
    [SerializeField] private SpriteRenderer Press;

    private Color pressed = Color.red;
    private Color held = Color.orange;
    private Color released = Color.yellow;

    private void OnEnable()
    {
        actionReference.action.Enable();
    }

    private void OnDisable()
    {
        actionReference.action.Disable();
    }

    private void Start()
    {
        Press = GetComponent<SpriteRenderer>();
        XPressHoldRelease = InputSystem.actions.FindAction("Xkey");
        if (!(actionReference.action.interactions.Contains("Press") && actionReference.action.interactions.
        Contains("Hold") && actionReference.action.interactions.Contains("Release")))
        {
            return;
        }

        actionReference.action.started += context =>
        {
            if (context.interaction is PressInteraction)
            {
                Press.material.color = pressed;
                print($"Pressed");
            }

            else if (context.interaction is HoldInteraction)
            {
                Hold.color = held;
                print($"Held");
            }

            else if (context.interaction is HoldInteraction)
            {
                Release.color = released;
                print($"Released");
            }
        };
    }
}
            

