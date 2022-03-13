using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TextColorHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Text theText;
    public Color theColor;

    public void OnPointerEnter(PointerEventData eventData)
    {
        theText.color = theColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        theText.color = Color.white;
    }
}
