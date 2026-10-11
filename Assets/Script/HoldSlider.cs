using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class HoldSlider : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    InputAction xAction;
    InputAction zAction;
    private bool PointerEntered = false;

    private MovingPlatform movingPlatformScript;
    private HighScore highScoreScript;

    [SerializeField] private float HitCounter = 0f;
    [SerializeField] private float PayPerSecond = 1f;
    private float Pay = 0f;

    [SerializeField] Camera mainCam;

    private void Start()
    {
        xAction = InputSystem.actions.FindAction("Xkey");
        zAction = InputSystem.actions.FindAction("Zkey");
        movingPlatformScript = GetComponent<MovingPlatform>();
        highScoreScript = GetComponent<HighScore>();
        enabled = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
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
            if (xAction.IsPressed())
            {
                PayAmount();
            }

            else if (xAction.WasReleasedThisFrame())
            {
                print($"X key released On {this.name}!");
                print($"Miss");
                enabled = false;
            }

            if (zAction.IsPressed())
            {
                PayAmount();
            }

            else if (zAction.WasReleasedThisFrame())
            {
                print($"Z key released On {this.name}!");
                print($"Miss");
                enabled = false;
            }
        }

    }

    void PayAmount()
    {
            HitCounter += Time.deltaTime;
            // Convert seconds held into pay
            Pay = (HitCounter / 2) * PayPerSecond;

            print($"Hit Counter: {HitCounter} seconds, Pay: {Pay}");
    }

    public void EnableHold()
    {
        enabled = true;
    }

}

