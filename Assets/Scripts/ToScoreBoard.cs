using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToScoreBoard : MonoBehaviour
{
    [SerializeField] private Animator cameraAnimation;
    [SerializeField] private Animator madTeacherAnimation;

    private void Update()
    {
         cameraAnimation.enabled = true;
         madTeacherAnimation.enabled = true;
    }
}
