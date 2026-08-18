using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class HoldColour : MonoBehaviour
{
    InputAction xAction;
    InputAction zAction;
    private bool PointerEntered = false;
    [SerializeField] private Transform payBarFill;
    [SerializeField] private float fillSpeed;
    [SerializeField] private Gradient colourGradient;
    private SpriteRenderer spriteRenderer;
    private void Start()
    {
        xAction = InputSystem.actions.FindAction("Xkey");
        zAction = InputSystem.actions.FindAction("Zkey");
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
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
        //need to make mouse position between a set value (e.g. 0-1) which is then followed by gradient
        //now how do i possibly do that
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        float left = sr.localBounds.min.x;
        float right = sr.localBounds.max.x;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.value);
        Vector2 direction = (mousePos - transform.position).normalized;
        currentPay = direction;

        //set minimum to 0 and maximum to max pay
        currentPay = Mathf.Clamp(left, 0f, right);
        Update();
    }

    void Update()
    {
        if (PointerEntered == true)
        {
            if (xAction.IsPressed())
            {
                print($"X key properly Pressed On {this.name}!");
                float targetFillAmount = currentPay / maxPay;
                //set fill amount of fill image to target value

                //while doing this, gradient follows cursor
                payBarFill.DOFillAmount(targetFillAmount, fillSpeed);
                payBarFill.DOColor(colourGradient.Evaluate(targetFillAmount), fillSpeed);

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