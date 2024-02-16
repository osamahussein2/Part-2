using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressButtons : MonoBehaviour
{
    public void Press16x9Button()
    {
        Screen.SetResolution(1600, 900, false);
    }

    public void PressFullHDButton()
    {
        Screen.SetResolution(1920, 1080, false);
    }

    public void PressNextSceneButton()
    {
        SceneManager.LoadScene("Scene5");
    }
}
