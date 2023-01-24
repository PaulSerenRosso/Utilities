using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace HelperPSR.UI
{
public static class UIHelper 
{
    public static bool InputMouseIsInCanvasArea(this RectTransform _canvasArea)
    {
        if (RectTransformUtility.RectangleContainsScreenPoint(_canvasArea, Input.mousePosition))
        {
            return true;
        }
        return false;
    }
    public static Vector3 GetWorldPositionOfCanvasElement(this RectTransform _element) // Find world point of canvas elements
    {
        RectTransformUtility.ScreenPointToWorldPointInRectangle(_element, _element.position, Camera.main, out var result);
        return result;
    }
    public static Vector2 GetCanvasPositionOfWorldElement(this Transform _element) // Find world point of canvas elements
    {
        return RectTransformUtility.WorldToScreenPoint(Camera.main, _element.position);;
    }
    
    public static void SetWidth(this RectTransform rt, float w)
    {
        rt.sizeDelta = new Vector2(w, rt.sizeDelta.y);
    }

    public static void SetHeight(this RectTransform rt, float h)
    {
        rt.sizeDelta = new Vector2(rt.sizeDelta.x, h);
    }

    public static void SetSize(this RectTransform rt, float size)
    {
        rt.sizeDelta = new Vector2(size, size);
    }

    public static float GetWidth(this RectTransform rt)
    {
        return rt.sizeDelta.x;
    }

    public static float GetHeight(this RectTransform rt)
    {
        return rt.sizeDelta.y;
    }
    
    public static void SetAnchored(this RectTransform rectTransform, Vector2 newAnchored)
    {
        rectTransform.anchoredPosition = newAnchored;
    }

    public static void SetAnchoredX(this RectTransform rectTransform, float newAnchoredX)
    {
        Vector2 anchor = rectTransform.anchoredPosition;
        anchor.x = newAnchoredX;
        rectTransform.anchoredPosition = anchor;
    }

    public static void SetAnchoredY(this RectTransform rectTransform, float newAnchoredY)
    {
        Vector2 anchor = rectTransform.anchoredPosition;
        anchor.y = newAnchoredY;
        rectTransform.anchoredPosition = anchor;
    }
    
    public static void SetAlpha(this Image image, float alpha)
    {
        Color c = image.color;
        c.a = alpha;
        image.color = c;
    }
    
    public static void NoInteractions(this CanvasGroup canvasGroup)
    {
        canvasGroup.interactable = canvasGroup.blocksRaycasts = false;
    }

    public static void EnableInteractions(this CanvasGroup canvasGroup)
    {
        canvasGroup.interactable = canvasGroup.blocksRaycasts = true;
    }

}
}
