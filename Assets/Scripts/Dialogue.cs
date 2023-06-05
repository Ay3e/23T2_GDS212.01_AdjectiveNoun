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
    private bool isPaused;
    private int blankCount;

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
            else if (isPaused) // Resume dialogue if paused
            {
                isPaused = false;
                StartCoroutine(TypeLine());
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            if (textComponent.text == lines[index]) // Check if the line is fully displayed
            {
                if (lines[index].Contains("_")) // Check if "_" is present in the line
                {
                    isPaused = true;
                }
                else
                {
                    NextLine();
                }
            }
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
                blankCount++;
                if(blankCount == 13)
                {
                    isPaused = true;
                    yield return new WaitUntil(() => !isPaused); // Wait until isPaused becomes false
                    blankCount = 0;
                }
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
        if(index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
