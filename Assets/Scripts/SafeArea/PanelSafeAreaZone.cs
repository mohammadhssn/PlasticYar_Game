using System;
using UnityEngine;

public class PanelSafeAreaZone : MonoBehaviour
{
    public Canvas canvas;
    private RectTransform panelSafeArea;

    private Rect currentSafeArea = new Rect();
    private ScreenOrientation currentOrientation = ScreenOrientation.AutoRotation;

    private void Awake()
    {
        panelSafeArea = GetComponent<RectTransform>();
        currentOrientation = Screen.orientation;
        currentSafeArea = Screen.safeArea;

        ApplySafeArea();
    }

    void ApplySafeArea()
    {
        if(panelSafeArea == null)
            return;

        Rect safeAreza = Screen.safeArea;

        Vector2 anchorMin = safeAreza.position;
        Vector2 anchorMax = safeAreza.position + safeAreza.size;

        anchorMin.x /= canvas.pixelRect.width;
        anchorMin.y /= canvas.pixelRect.height;

        anchorMax.x /= canvas.pixelRect.width;
        anchorMax.y /= canvas.pixelRect.height;

        panelSafeArea.anchorMin = anchorMin;
        panelSafeArea.anchorMax = anchorMax;

        currentOrientation = Screen.orientation;
        currentSafeArea = Screen.safeArea;
    }

    
    private void Update()
    {
        if ((currentOrientation != Screen.orientation) || (currentSafeArea != Screen.safeArea))
        {
            ApplySafeArea();
        }
    }
}