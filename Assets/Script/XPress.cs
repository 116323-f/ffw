using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class XPress : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    InputAction xAction;
    private bool PointerEntered = false;
    [SerializeField] private Color pressedColour;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        xAction = InputSystem.actions.FindAction("Xkey");
        spriteRenderer = GetComponent<SpriteRenderer>();
        enabled = false;
    }

    //method status and name(what the method contains)
    public void OnPointerEnter(PointerEventData eventData)
    {
        //what the method does

        print($"On Mouse Enter On {this.name}!");
        PointerEntered = true;

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        print($"On Mouse Exit On {this.name}!");
        PointerEntered = false;
        print($"Miss");
        enabled = false;
    }

    void Update()
    {
        if (PointerEntered == true)
        {
            if (xAction.WasPressedThisFrame() && xAction.IsPressed())
            {
                print($"X key properly Pressed On {this.name}!");
                spriteRenderer.color = pressedColour;
                enabled = false;
            }

        }

    }

    public void EnablePress()
    {
        enabled = true;
        print($"XPress script enabled on {this.name}");
    }
}