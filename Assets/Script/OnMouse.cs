using UnityEngine;
using UnityEngine.EventSystems;

public class OnMouse : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{

    public void OnPointerEnter(PointerEventData eventData)
    {
        print($"New Input System: On Mouse Enter Called On {this.name}!");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        print($"New Input System: On Mouse Exit Called On {this.name}!");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left) print("Left button pressed");
        else print("Another button pressed");
    }

}
