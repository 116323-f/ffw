using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerKeys : MonoBehaviour
{
    InputAction xAction;
    InputAction zAction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        xAction = InputSystem.actions.FindAction("Xkey");
        zAction = InputSystem.actions.FindAction("Zkey");
    }

    // Update is called once per frame
    void Update()
    {
        if (xAction.WasPressedThisFrame())
        {
            print($"X key Pressed On {this.name}!");
        }

        if (xAction.WasReleasedThisFrame())
        {
            print($"X key Released On {this.name}!");
        }

        if (zAction.WasPressedThisFrame())
        {
            print($"Z key Pressed On {this.name}!");
        }

        if (zAction.WasPressedThisFrame())
        {
            print($"Z key Released On {this.name}!");
        }
    }
}
