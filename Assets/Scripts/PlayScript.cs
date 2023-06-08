using UnityEngine;

public class PlayScript : MonoBehaviour
{
    [SerializeField] private Animator titleAnimation;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private GameObject brush;
    [SerializeField] private GameObject button;
    [SerializeField] private GameObject script;
    private float timer;

    private void Start()
    {
        brush.SetActive(false);
    }
    private void Update()
    {
        Debug.Log(timer);
        timer += Time.deltaTime;
        if (timer >= 2f)
        {
            ActivateDialoguePanel();
        }
        titleAnimation.enabled = true;
        button.SetActive(false);
    }

    private void ActivateDialoguePanel()
    {
        dialoguePanel.SetActive(true);
    }
}