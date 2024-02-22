using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GoalScored : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        Controller.score = 0;
        scoreText.text = "Score: " + Controller.score; // Show the score text at start and set it to 0 first
    }

    void Update()
    {
        scoreText.text = "Score: " + Controller.score; // Updating the score during runtime
    }
}
