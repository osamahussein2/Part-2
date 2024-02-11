using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    // A list of Vector2 points are needed for use in determining previous and current mouse positions
    public List<Vector2> points;
    Vector2 lastPosition;
    float pointThreshold = 0.1f;

    // Use the line renderer component to draw a line with mouse input
    LineRenderer lineRenderer;

    // This is used for the rigidbody movement
    Rigidbody2D rigidbody;
    Vector2 currentPosition;

    float speed = 1;

    public GameObject diamond; // I'll use diamond object inside the inspector so that it can be spawned
    float diamondTimer; // Spawn the diamond by using the diamond timer

    public GameObject coal; // I'll use coal object inside the inspector so that it can be spawned
    float coalTimer; // Spawn the coal by using the coal timer

    public int score; // Show the score inside the inspector to prove that it's working with the score UI

    public float health; // Show player's health inside the inspector to prove it's woring with the health bar UI
    private float maxHealth = 3; // Make this private so that this variable can't be modified in the inspector

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();

        lineRenderer.positionCount = 1; // Initialize the first index point
        lineRenderer.SetPosition(0, transform.position); // Set its position to transform's position at the start

        rigidbody = GetComponent<Rigidbody2D>();

        score = 0; // Make it 0 at the start because the player hasn't collected the diamonds yet

        health = maxHealth; // Make health equal to full health at the start

        /* Write to the console what the player needs to do to not be stuck when moving their player away
        from the screen boundaries */
        Debug.Log("When the player gets stuck when trying to go offscreen, the player needs to put their" +
            " mouse on the sprite's bottom tie and draw a line away from the screen boundaries because of the" +
            " way of the sprite's pivot point is set up to be at the bottom center instead of center (so that" +
            " the star trails render below the player rather than where the player's center is)");
    }

    // Update is called once per frame
    void Update()
    {
        // Set its position to update on each frame
        lineRenderer.SetPosition(0, transform.position);

        /* If there is more than 0 points and if the distance between the current position and first point are
        less than the point threshold, then remove the first point */
        if (points.Count > 0)
        {
            if (Vector2.Distance(currentPosition, points[0]) < pointThreshold)
            {
                points.RemoveAt(0);

                // This is mandatory so that the starting point doesn't stay in the game forever
                for (int i = 0; i < lineRenderer.positionCount - 2; i++)
                {
                    lineRenderer.SetPosition(i, lineRenderer.GetPosition(i + 1));
                }

                // Decrease the position count so that the end point doesn't stay in the game forever
                lineRenderer.positionCount--;
            }
        }

        // Create if statements so that the player can't go offscreen

        if (transform.position.x <= -8.9f) // Left side of the screen
        {
            transform.position = new Vector2(-8.9f, transform.position.y);
        }

        if (transform.position.x >= 8.9f) // Right side of the screen
        {
            transform.position = new Vector2(8.9f, transform.position.y);
        }

        if (transform.position.y <= -3.8f) // Below the screen
        {
            transform.position = new Vector2(transform.position.x, -3.8f);
        }

        if (transform.position.y >= 3.8f) // Above the screen
        {
            transform.position = new Vector2(transform.position.x, 3.8f);
        }

        // Increment the diamond timer by deltaTime and spawn it after 3 seconds, then randomize the diamond timer
        diamondTimer += Time.deltaTime;

        if (diamondTimer > 3)
        {
            Instantiate(diamond, transform.position, Quaternion.identity);
            diamondTimer = Random.Range(1, 3);
        }

        // Increment the coal timer by deltaTime and spawn it after 8 seconds, then randomize the coal timer
        coalTimer += Time.deltaTime;

        if (coalTimer > 8)
        {
            Instantiate(coal, transform.position, Quaternion.identity);
            coalTimer = Random.Range(4, 8);
        }
    }

    private void FixedUpdate()
    {
        // Apparently, removing this current position variable will make my player spin endlessly
        currentPosition = transform.position;

        // If there is more than 0 points, then rotate the rigidbody at any angle
        if (points.Count > 0)
        {
            Vector2 direction = points[0] - currentPosition;
            float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            rigidbody.rotation = -angle;
        }

        // Move the rigidbody object up on each fixed update
        rigidbody.MovePosition(rigidbody.position + (Vector2)transform.up * speed * Time.deltaTime);
    }

    private void OnMouseDown()
    {
        // Initialize the list of points
        points = new List<Vector2>();

        // Set the position count to the first index point, and set its position to transform's position
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);
    }

    private void OnMouseDrag()
    {
        // This is used to draw a new line each time the player drags the mouse on the game object
        Vector2 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Add the list of points with its new position to render the line and make the player follow the line path
        if (Vector2.Distance(lastPosition, newPosition) > pointThreshold)
        {
            points.Add(newPosition);
            lineRenderer.positionCount++;
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, newPosition);
            lastPosition = newPosition;
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
