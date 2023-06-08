using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageScene : MonoBehaviour
{
    void ButtonToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
