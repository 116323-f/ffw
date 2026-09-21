using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class HoldSlider : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Transform sliderBall;
    public float hitRadius = 1.5f;

    InputAction xAction;
    InputAction zAction;
    InputAction MousePosition;
    private bool PointerEntered = false;

    private HoldSlider script;
    private HighScore script2;

    private bool isTracking = false;

    [SerializeField] private float HitCounter = 0f;
    [SerializeField] private float PayPerSecond = 1f;
    private float Pay = 0f;

    [SerializeField] Camera mainCam;

    private void Start()
    {
        xAction = InputSystem.actions.FindAction("Xkey");
        zAction = InputSystem.actions.FindAction("Zkey");
        MousePosition = InputSystem.actions.FindAction("MousePosition");
        script = GetComponent<HoldSlider>();
        script2 = GetComponent<HighScore>();
        script.enabled = true;
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
        script.enabled = false;
    }

    void Update()
    {
        if (PointerEntered == true)
        {
            if (xAction.IsPressed())
            {
                //Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Mouse.current.position);
                //worldPos = mainCam.ScreenToWorldPoint(Mouse.current.position);
                //mouseWorldPos.x = 0f;

                //float distance = Vector2.Distance(mouseWorldPos, sliderBall.position);

                //isTracking = distance <= hitRadius;


//                Vector2 mousePosition = mousePositionReference.action.ReadValue<Vector2>();
//#else
//        Vector2 mousePosition = Input.mousePosition;
//#endif
//                mousePosition.z = 20;
//                mousePosition = camera.ScreenToWorldPoint(mousePosition);
//                mousePosition.z = 0;
//                mouseCursor.position = mousePosition;

                Vector2 mousePosition = Camera.main.ScreenToViewportPoint(Mouse.current.position.ReadValue());
                //Vector2 worldPos = mainCam.ScreenToWorldPoint(Mouse.current.position.ReadValue());
                //mousePosition.x = 0f;
                //mousePosition.y = 0f;

                float distance = Vector2.Distance(mousePosition, sliderBall.position);

                print("{distance}");

                if (distance <= hitRadius)
                {
                    isTracking = true;
                    PayAmount();
                }
            }

            else if (xAction.WasReleasedThisFrame())
            {
                print($"X key released On {this.name}!");
                print($"Miss");
                script.enabled = false;
                isTracking = false;
            }

            if (zAction.IsPressed())
            {

            }

            else if (zAction.WasReleasedThisFrame())
            {
                print($"Z key released On {this.name}!");
                print($"Miss");
                script.enabled = false;
                isTracking = false;
            }
        }

    }

    void PayAmount()
    {
        if (isTracking == true)
        {
            print($"Hello I am tracking");

            HitCounter += Time.deltaTime;
            // Convert seconds held into pay
            Pay = (HitCounter / 2) * PayPerSecond;

            print($"Hit Counter: {HitCounter} seconds, Pay: {Pay}");
        }
    }
}

