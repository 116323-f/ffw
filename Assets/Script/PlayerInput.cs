using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    PlayerControls playerControls;

    private void Awake()
    {
        playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    void NewInputSystem()
    {

        bool isXKeyHeld = playerControls.Player.Xkey.ReadValue<float>() > 0.1f;

        if (isXKeyHeld)
        {
            print("X Key is down");
        }
    }
}
