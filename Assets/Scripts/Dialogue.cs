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
    private bool isBrushActive;
    [SerializeField] private GameObject flashingText;
    [SerializeField] private GameObject brush;
    [SerializeField] private GameObject spaceToContinueText;

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
        if(index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
            if (index == 1)
            {
                Debug.Log("hi");
                //enable flahsing text
                flashingText.SetActive(true);
                //enable brush
                brush.SetActive(true);
                isBrushActive = true;
                //when mouse(0) is pressed then active space to continue
                if(isBrushActive==true && Input.GetMouseButtonDown(0))
                {
                    
                    spaceToContinueText.SetActive(true);
                }
            }
        }
        else
        {
            //gameObject.SetActive(false);
        }
    }
}
