using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    private int index;
    [SerializeField] private GameObject flashingText;
    [SerializeField] private GameObject brush;
    [SerializeField] private GameObject spaceToContinueText;
    public Draw drawScript; // Reference to the Draw script

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
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            drawScript.brushCount = 0;
        }
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
                flashingText.SetActive(true); // Enable flashing text
                brush.SetActive(true); // Enables brush to be active
            }
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}