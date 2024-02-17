using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    // 2 texts will be used for the game over text and how the player did text (depending on player's score)
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI playerAccomplishmentText;

    // This is needed to use SendMessage for IncreaseScore
    private int score;

    // This is needed to use SendMessage for LowerHealth and IncreaseScore
    private int health;
    private int maxHealth = 3;

    // Start is called before the first frame update
    void Start()
    {
        score = 0; // Make it 0 at the start because the player hasn't collected the diamonds yet

        health = maxHealth; // Make health equal to full health at the start
    }

    // Update is called once per frame
    void Update()
    {
        // Update the player's final score when the player's health is at 0
        if (health <= 0)
        {
            // The player will receive this game over text if their score is at least 0 but less than 50 
            if (score >= 0 && score < 50)
            {
                gameOverText.text = "Game Over!";
                gameOverText.color = Color.red;
            }

            // The player will receive this game over text if their score is at least 50
            if (score >= 50)
            {
                gameOverText.text = "You won!";
                gameOverText.color = Color.green;
            }

            if (score == 0)
            {
                // If the player didn't catch a diamond, tell the player this
                playerAccomplishmentText.text = "You didn't catch any diamonds! Your final score is "
                    + score + "!";
            }

            // If the player catches at least 1 diamond but less than 10 diamonds
            if (score > 0 && score < 10)
            {
                playerAccomplishmentText.text = "At least you caught a few diamonds! But still do better than that!" +
                    " Your final score is " + score + "!";
            }

            // If the player catches at least 10 diamond but less than 20 diamonds
            if (score >= 10 && score < 20)
            {
                playerAccomplishmentText.text = "Keep catching those diamonds! Your final score" +
                    " is " + score + "!";
            }

            // If the player catches at least 20 diamond but less than 30 diamonds
            if (score >= 20 && score < 30)
            {
                playerAccomplishmentText.text = "You're getting there! Catch more diamonds! Your final score" +
                    " is " + score + "!";
            }

            // If the player catches at least 30 diamond but less than 40 diamonds
            if (score >= 30 && score < 40)
            {
                playerAccomplishmentText.text = "You still need more diamonds to catch! Keep at it!" +
                    " Your final score is " + score + "!";
            }

            // If the player catches at least 40 diamond but less than 50 diamonds
            if (score >= 40 && score < 50)
            {
                playerAccomplishmentText.text = "You're getting very close to 50! Just a few more diamonds!" +
                    " Your final score is " + score + "!";
            }

            // If the player catches at least 50 diamonds
            if (score >= 50)
            {
                playerAccomplishmentText.text = "You've caught at least 50 diamonds! Nice job! Your final score" +
                    " is " + score + "!";
            }
        }
    }

    public void LowerHealth()
    {
        // Decrement player health
        health--;

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
        if (health <= 0)
        {
            score += 0;
        }
    }
}

