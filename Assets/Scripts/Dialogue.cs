using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    private int index;
    [SerializeField] private GameObject flashingText;
    [SerializeField] private GameObject brush;
    [SerializeField] private GameObject spaceToContinueText;
    [SerializeField] private TextMeshProUGUI dialoguePanel;
    public Draw drawScript; // Reference to the Draw script
    [SerializeField] private GameObject toFinalScoreAnimation;
    private bool isDialogueFinished = false;


    private void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
        if (index == 1 && drawScript.brushCount > 0)
        {
            flashingText.SetActive(false);
            spaceToContinueText.SetActive(true);
            isDialogueFinished = true;
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            drawScript.brushCount = 0;
        }
        AnimateToScoreBoard();
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            if (c == '_')
            {
                textComponent.text += c;
            }
            else
            {
                textComponent.text += c;
                yield return new WaitForSeconds(textSpeed);
            }
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
            if (index == 1)
            {
                // Enable flashing text
                flashingText.SetActive(true);
                // Enable brush to be active
                brush.SetActive(true); 
            }
        }
        else
        {
            gameObject.GetComponent<Image>().enabled = false;
            dialoguePanel.enabled = false;
        }
    }

    void AnimateToScoreBoard()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isDialogueFinished)
        {
            flashingText.SetActive(false);
            spaceToContinueText.SetActive(false);
            toFinalScoreAnimation.SetActive(true);
            gameObject.GetComponent<Image>().enabled = false;
            dialoguePanel.enabled = false;
        }
    }
}