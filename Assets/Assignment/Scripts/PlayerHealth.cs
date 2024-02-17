using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Image[] fullHealth; // I'll use a full health bar image inside the inspector
    public Image[] noHealth; // I'll use a no health bar image inside the inspector

    private int health; // Show player's health inside the inspector to prove it's woring with the health bar UI
    private int maxHealth = 3; // Make this private so that this variable can't be modified in the inspector

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth; // Make health equal to full health at the start
    }

    // Update is called once per frame
    void Update()
    {
        // If the health is less than or equal to 0, make all of the no health bar images active in the hierarchy
        // And make all of the full health bar images to not active in the hierarchy
        if (health <= 0)
        {
            for (int i = 0; i < noHealth.Length; i++)
            {
                noHealth[i].gameObject.SetActive(true);
                fullHealth[i].gameObject.SetActive(false);
            }
        }

        // If the health is equal to 1, make the last 2 no health bar images active (rest are not active)
        // And make the full health 1 image active (rest are not active)
        if (health == 1)
        {
            fullHealth[0].gameObject.SetActive(true);
            fullHealth[1].gameObject.SetActive(false);
            fullHealth[2].gameObject.SetActive(false);

            noHealth[0].gameObject.SetActive(false);
            noHealth[1].gameObject.SetActive(true);
            noHealth[2].gameObject.SetActive(true);
        }

        // If the health is equal to 2, make the last no health bar image active (rest are not active)
        // And make the first 2 full health imagex active (rest are not active)
        if (health == 2)
        {
            fullHealth[0].gameObject.SetActive(true);
            fullHealth[1].gameObject.SetActive(true);
            fullHealth[2].gameObject.SetActive(false);

            noHealth[0].gameObject.SetActive(false);
            noHealth[1].gameObject.SetActive(false);
            noHealth[2].gameObject.SetActive(true);
        }

        // If the health is equal to 3 (or max health), make all of the full health bar images active
        // And make all of the no health bar images not active
        if (health == maxHealth)
        {
            for (int i = 0; i < fullHealth.Length; i++)
            {
                fullHealth[i].gameObject.SetActive(true);
                noHealth[i].gameObject.SetActive(false);
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
}
