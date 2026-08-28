using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Hold : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    InputAction xAction;
    InputAction zAction;
    private bool PointerEntered = false;
    private bool Hit = false;
    public int HitCounter = 0;
    [SerializeField] private Color pressedColor = Color.red;

    private SpriteRenderer spriteRenderer;
    private Color originalColor;

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

    void Update()
    {
        if (PointerEntered == true)
        {
            if (xAction.IsPressed())
            {
                print($"X key properly Pressed On {this.name}!");
                spriteRenderer.color = pressedColor;
                Hit = true;
                ProperlyHit();
            }

            else if (xAction.WasReleasedThisFrame())
            {
                print($"X key released On {this.name}!");
                spriteRenderer.color = originalColor;
                Hit = false;
                NotProperlyHit();
            }

            if (zAction.IsPressed())
            {
                print($"Z key properly Pressed On {this.name}!");
                Hit = true;
                ProperlyHit();
            }

            else if (zAction.WasReleasedThisFrame())
            {
                print($"Z key released On {this.name}!");
                Hit = false;
                NotProperlyHit();
            }
        }
    }

    //count up hitcounter by seconds held and convert this into pay 
    private void ProperlyHit()
    {
        while (Hit == true)
        {
            HitCounter ++ ;
            print($"HitCounter: " + HitCounter);

            return;

        }
    }

    //stop hitcounter and set note to null so its unable to be pressed any longer.
    //make sure to only set this for that single note missed
    private void NotProperlyHit()
    {
        
    }


}