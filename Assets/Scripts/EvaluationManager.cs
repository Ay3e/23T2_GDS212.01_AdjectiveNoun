using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvaluationManager : MonoBehaviour
{
    [SerializeField] private GameObject[] scorePossibilities;
    [SerializeField] private GameObject[] teacherExpressions;
    [SerializeField] private AudioSource audioSource;
    public GameObject finalScore;

    private int randomisedScoreGenerator = 0;
    private bool expressionActivated = false;

    // Start is called before the first frame update
    void Start()
    {
        randomisedScoreGenerator = Random.Range(0, 7);

        for (int i = 0; i < 6; i++)
        {
            if (randomisedScoreGenerator >= 4)
            {
                finalScore = scorePossibilities[4];
            }
            else if(randomisedScoreGenerator == i)
            {
                finalScore = scorePossibilities[i];
            }
        }
    }

    private void Update()
    {
        if (!expressionActivated && Dialogue.isDialogueFinished && Dialogue.timerSetToZero)
        {
            Dialogue.timer += Time.deltaTime;

            if (Dialogue.timer >= 2.1f)
            {
                audioSource.enabled = true;
            }

            if (Dialogue.timer >= 2.66f)
            {
                ActivateExpression();
                finalScore.SetActive(true);
            }
        }
    }

    private void ActivateExpression()
    {
        if (randomisedScoreGenerator >= 3)
        {
            teacherExpressions[2].SetActive(true);
        }
        else if (randomisedScoreGenerator == 0)
        {
            teacherExpressions[0].SetActive(true);
        }
        else
        {
            teacherExpressions[1].SetActive(true);
        }

        expressionActivated = true;
    }
}