using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnMouse : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public void OnPointerEnter(PointerEventData eventData)
    {
        print($"On Mouse Enter On {this.name}!");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        print($"On Mouse Exit On {this.name}!");
    }


}
