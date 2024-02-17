using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    // When the player presses the play button, take them to the diamond hunter game
    public void PressPlayButton()
    {
        SceneManager.LoadScene("DiamondHunter");
    }

    // When the player presses the how to play button, take them to the how to play scene
    public void PressHowToPlayButton()
    {
        SceneManager.LoadScene("HowToPlay");
    }

    // Only available when the player pressed the how to play button (inside the how to play scene)
    public void PressBackButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
