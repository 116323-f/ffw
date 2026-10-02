using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class HoldSlider : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Transform sliderBall;
    public float hitRadius = 1f;

    InputAction xAction;
    InputAction zAction;
    private bool PointerEntered = false;

    private HoldSlider holdScoreScript;
    private HighScore highScoreScript;

    [SerializeField] private float HitCounter = 0f;
    [SerializeField] private float PayPerSecond = 1f;
    private float Pay = 0f;

    [SerializeField] Camera mainCam;

    private void Start()
    {
        xAction = InputSystem.actions.FindAction("Xkey");
        zAction = InputSystem.actions.FindAction("Zkey");
        holdScoreScript = GetComponent<HoldSlider>();
        highScoreScript = GetComponent<HighScore>();
        holdScoreScript.enabled = true;
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
        holdScoreScript.enabled = false;
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
                holdScoreScript.enabled = false;
            }

            if (zAction.IsPressed())
            {
                PayAmount();

            }

            else if (zAction.WasReleasedThisFrame())
            {
                print($"Z key released On {this.name}!");
                print($"Miss");
                highScoreScript.enabled = false;
            }
        }

    }

    void PayAmount()
    {
            print($"Hello I am tracking");

            HitCounter += Time.deltaTime;
            // Convert seconds held into pay
            Pay = (HitCounter / 2) * PayPerSecond;

            print($"Hit Counter: {HitCounter} seconds, Pay: {Pay}");
    }
}

