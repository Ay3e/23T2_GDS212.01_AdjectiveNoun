using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageScene : MonoBehaviour
{
    [SerializeField] private GameObject sceneScript;

    // Update is called once per frame

    public void ButtonToPlay()
    {
        sceneScript.GetComponent<PlayScript>().enabled = true;
    }
}
