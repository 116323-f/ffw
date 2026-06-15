using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnMouse : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public void OnPointerEnter(PointerEventData eventData)
    {
        print($"New Input System: On Mouse Enter Called On {this.name}!");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        print($"New Input System: On Mouse Exit Called On {this.name}!");
    }

    

}
