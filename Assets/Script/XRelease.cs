using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class XRelease : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    InputAction xAction;
    private bool PointerEntered = false;
    [SerializeField] private Color releasedColour;
    private SpriteRenderer spriteRenderer;
    private float Pay = 0f;

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
            if (xAction.WasReleasedThisFrame())
            {
                print($"X key properly released On {this.name}!");
                spriteRenderer.color = releasedColour;
                Pay++;
                print($"Pay: {Pay}");
                enabled = false;
            }
        }

    }

    public void EnableRelease()
    {
        enabled = true;
        print($"XRelease script enabled on {this.name}");
    }

}
