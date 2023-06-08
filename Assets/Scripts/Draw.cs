using UnityEngine;

public class Draw : MonoBehaviour
{
    public Camera m_camera;
    public GameObject brush;
    public Collider2D boundary;
    public AudioClip drawingSound; // Audio clip for drawing

    private AudioSource audioSource;
    private LineRenderer currentLineRenderer;
    private Vector2 lastPos;
    public int brushCount;
    private bool isDrawing;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = drawingSound;
    }

    private void Update()
    {
        DrawLine();
    }

    void DrawLine()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            CreateBrush();
            isDrawing = true;
            audioSource.Play(); // Start playing the audio when drawing begins
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            Vector2 mousePos = m_camera.ScreenToWorldPoint(Input.mousePosition);

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
            if (isDrawing)
            {
                isDrawing = false;
                audioSource.Stop(); // Stop playing the audio when drawing stops
            }
            currentLineRenderer = null;
        }
    }

    void CreateBrush()
    {
        if (!brush.activeSelf)
        {
            return;
        }

        GameObject brushInstance = Instantiate(brush);
        currentLineRenderer = brushInstance.GetComponent<LineRenderer>();

        Vector2 mousePos = m_camera.ScreenToWorldPoint(Input.mousePosition);

        currentLineRenderer.SetPosition(0, mousePos);
        currentLineRenderer.SetPosition(1, mousePos);
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