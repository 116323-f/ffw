using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class ZPress : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    InputAction zAction;
    private bool PointerEntered = false;
    [SerializeField] private Color pressedColour;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        zAction = InputSystem.actions.FindAction("Zkey");
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
            if (zAction.WasPressedThisFrame() && zAction.IsPressed())
            {
                print($"Z key properly Pressed On {this.name}!");
                spriteRenderer.color = pressedColour;
                enabled = false;
            }

        }

    }

    public void EnablePress()
    {
        enabled = true;
        print($"ZPress script enabled on {this.name}");
    }
}