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

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();

        lineRenderer.positionCount = 1; // Initialize the first index point
        lineRenderer.SetPosition(0, transform.position); // Set its position to transform's position at the start

        rigidbody = GetComponent<Rigidbody2D>();
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
}
