using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvaluationManager : MonoBehaviour
{
    [SerializeField] private GameObject[] scorePossibilities;
    [SerializeField] private GameObject[] teacherExpressions;
    private int randomisedScoreGenerator = 0;

    private bool expressionActivated = false;
    private bool scoreActivated = false;

    // Start is called before the first frame update
    void Start()
    {
        randomisedScoreGenerator = Random.Range(0, 6);
        for (int i = 0; i < 6; i++)
        {
            if (randomisedScoreGenerator >= 4)
            {
                scorePossibilities[4].SetActive(true);
                scoreActivated = true;
            }
            else if (randomisedScoreGenerator == i)
            {
                scorePossibilities[i].SetActive(true);
                scoreActivated = true;
            }
        }
    }

    private void Update()
    {
        if (scoreActivated && !expressionActivated && Dialogue.isDialogueFinished && Dialogue.timerSetToZero)
        {
            Dialogue.timer += Time.deltaTime;
            if (Dialogue.timer >= 2.66f)
            {
                ActivateExpression();
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