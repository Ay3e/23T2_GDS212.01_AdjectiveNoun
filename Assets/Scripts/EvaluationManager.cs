using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvaluationManager : MonoBehaviour
{
    [SerializeField] private GameObject[] scorePossibilities;
    private int randomisedScoreGenerator = 0;
    // Start is called before the first frame update
    void Start()
    {
        randomisedScoreGenerator = Random.Range(0, 4);
        for(int i=0; i<4; i++)
        {
            if (randomisedScoreGenerator == i)
            {
                scorePossibilities[i].SetActive(true);
            }
        }
    }
}