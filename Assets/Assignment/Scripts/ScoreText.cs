using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreText : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // I'll use the TextMeshPro component to display the score
    private int score; // This will show the score on the UI

    private int health; // This is needed so that I can put this variable inside the if statement
    private int maxHealth = 3; // This is only here so that I can initialize this to equal to the player's health


    // Start is called before the first frame update
    void Start()
    {
        score = 0; // Make it 0 at the start because the player hasn't collected the diamonds yet

        health = maxHealth; // Make health equal to full health at the start
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score; // Show the score UI to the player and update it on each frame
    }

    public void LowerHealth()
    {
        health--; // Decrement the player's health

        // If the player health is at 0, make it equal to 0 so that it doesn't decrement to a negative number
        if (health <= 0)
        {
            health = 0;
        }
    }

    public void IncreaseScore()
    {
        // Only increase the score if the player health is greather than 0
        if (health > 0)
        {
            score++;
        }

        // Don't increase the score if the player health is at 0 and if the score is equal to 0 or greater than 0
        if (health <= 0 && score >= 0)
        {
            score += 0;
        }
    }
}
