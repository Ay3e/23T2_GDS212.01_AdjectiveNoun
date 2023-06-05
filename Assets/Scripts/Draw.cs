using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draw : MonoBehaviour
{
    public Camera m_camera;
    public GameObject brush;
    public Collider2D boundary; // Reference to the boundary collider

    LineRenderer currentLineRenderer;
    Vector2 lastPos;

    private void Update()
    {
        DrawLine();
    }

    void DrawLine()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            CreateBrush();
        }
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Vector2 mousePos = m_camera.ScreenToWorldPoint(Input.mousePosition);

            // Check if the mouse position is within the boundary collider
            if (boundary == null || boundary.OverlapPoint(mousePos))
            {
                if (mousePos != lastPos)
                {
                    AddAPoint(mousePos);
                    lastPos = mousePos;
                }
            }
            else
            {
                currentLineRenderer = null;
            }
        }
        else
        {
            currentLineRenderer = null;
        }
    }

    void CreateBrush()
    {
        GameObject brushInstance = Instantiate(brush);
        currentLineRenderer = brushInstance.GetComponent<LineRenderer>();

        Vector2 mousePos = m_camera.ScreenToWorldPoint(Input.mousePosition);

        currentLineRenderer.SetPosition(0, mousePos);
        currentLineRenderer.SetPosition(1, mousePos);
    }

    void AddAPoint(Vector2 pointPos)
    {
        currentLineRenderer.positionCount++;
        int positionIndex = currentLineRenderer.positionCount - 1;
        currentLineRenderer.SetPosition(positionIndex, pointPos);
    }
}