using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class ReleaseButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    InputAction xAction;
    InputAction zAction;
    private bool PointerEntered = false;
    [SerializeField] private Color releasedColor = Color.red;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        xAction = InputSystem.actions.FindAction("Xkey");
        zAction = InputSystem.actions.FindAction("Zkey");
        spriteRenderer = GetComponent<SpriteRenderer>();
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
    }

    void Update()
    {
        if (PointerEntered == true)
        {
            if (xAction.WasReleasedThisFrame())
            {
                print($"X key properly released On {this.name}!");
                spriteRenderer.color = releasedColor;
            }

            if (zAction.WasReleasedThisFrame())
            {
                print($"Z key properly released On {this.name}!");
                spriteRenderer.color = releasedColor;
            }
        }

    }

}
