using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTrail : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public Camera mainCamera;

    private bool isDragging = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isDragging = true;
            lineRenderer.positionCount = 0; // Clear existing points
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            ClearTrail();
        }

        if (isDragging)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = -mainCamera.transform.position.z;
            Vector3 worldPos = mainCamera.ScreenToWorldPoint(mousePos);

            lineRenderer.positionCount++;
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, worldPos);
        }
    }
    private void ClearTrail()
    {
        lineRenderer.positionCount = 0;
    }
}