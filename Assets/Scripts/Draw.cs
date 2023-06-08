using UnityEngine;

public class Draw : MonoBehaviour
{
    public Camera m_camera;
    public GameObject brush;
    // Reference to the boundary collider
    public Collider2D boundary; 

    LineRenderer currentLineRenderer;
    Vector2 lastPos;
    // Counter for brush clones
    public int brushCount; 

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
        if (!brush.activeSelf)
        {
            // Exit the method if the brush is disabled
            return; 
        }

        GameObject brushInstance = Instantiate(brush);
        currentLineRenderer = brushInstance.GetComponent<LineRenderer>();

        Vector2 mousePos = m_camera.ScreenToWorldPoint(Input.mousePosition);

        currentLineRenderer.SetPosition(0, mousePos);
        currentLineRenderer.SetPosition(1, mousePos);
        // Increment the brush count
        brushCount++; 
        Debug.Log("Brush Count: " + brushCount);
    }

    void AddAPoint(Vector2 pointPos)
    {
        currentLineRenderer.positionCount++;
        int positionIndex = currentLineRenderer.positionCount - 1;
        currentLineRenderer.SetPosition(positionIndex, pointPos);
    }
}