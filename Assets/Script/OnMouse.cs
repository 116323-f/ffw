using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class OnMouse : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    InputAction xAction;
    InputAction zAction;
    private bool PointerEntered = false;

    private void Start()
    {
        xAction = InputSystem.actions.FindAction("Xkey");
        zAction = InputSystem.actions.FindAction("Zkey");
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
            if (xAction.WasPressedThisFrame() && xAction.IsPressed())
            {
                print($"X key properly Pressed On {this.name}!");
            }

            else if (xAction.WasReleasedThisFrame())
            {
                print($"X key properly released On {this.name}!");
            }

            if (zAction.WasPressedThisFrame() && zAction.IsPressed())
            {
                print($"Z key properly Pressed On {this.name}!");
            }

            else if (zAction.WasReleasedThisFrame())
            {
                print($"Z key properly released On {this.name}!");
            }
        }

    }

}