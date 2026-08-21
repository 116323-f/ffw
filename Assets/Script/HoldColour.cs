using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class HoldColour : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    InputAction xAction;
    InputAction zAction;
    private bool PointerEntered = false;
    [SerializeField] private Transform payBarFill;
    [SerializeField] private float fillSpeed;
    [SerializeField] private Gradient colourGradient;
    private SpriteRenderer spriteRenderer;
    private float mouseLog = 0;
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

        public void UpdatePay (PointerEventData eventData)
    {
        //gradient to follow cursor
        //need to convert mouse position to between a set value (e.g. 0-1) then using that value, implement a gradient
        //e.g. while mouse goes from 0 to 0.5, the gradient will follow from 0 to 0.5 as well
        //now how do i possibly do that
        SpriteRenderer sr = GetComponent<SpriteRenderer>();

        // find mouse coord
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.value);
        Vector2 direction = (mousePos - transform.position).normalized;
        print($"Current mouse position: " + mousePos);

        //convert mouse coord to float
        mouseLog = () / 1000;

        //fix mouse coord to inside shape
        float left = sr.localBounds.min.x;
        float right = sr.localBounds.max.x;
        mouseLog = Mathf.Clamp(left, 0f, right);

        Update();
    }

    void Update()
    {

        if (PointerEntered == true)
        {
            if (xAction.IsPressed())
            {
                print($"X key properly Pressed On {this.name}!");
                
                //set gradient to follow mouse coord
                
                //float targetFillAmount = currentPay / maxPay;
                //payBarFill.DOFillAmount(targetFillAmount, fillSpeed);
                //payBarFill.DOColor(colourGradient.Evaluate(targetFillAmount), fillSpeed);

            }

            else if (xAction.WasReleasedThisFrame())
            {
                print($"X key properly released On {this.name}!");

            }

            if (zAction.IsPressed())
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