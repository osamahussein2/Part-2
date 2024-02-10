using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    // This is for moving the diamond down when it's spawned for the player to catch to increase their score
    Vector2 moveDown;

    // This is needed to animate the movement of the diamond when it moves down
    Rigidbody2D rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        // Initialzie the diamond's position to be randomized across the screen
        transform.position = new Vector2(Random.Range(-9, 9), Random.Range(5, 10));
        
        // Move the coal down at random speeds
        moveDown = new Vector2(0, Random.Range(-0.1f, -1));

        // Get the rigidbody component to animate it
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        // Move the diamond down the screen by using deltaTime and update the movement on each fixed interval
        rigidbody.MovePosition(rigidbody.position + moveDown * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        // Destroy the diamond if it goes below the screen
        if (transform.position.y <= -5.0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If the player collided with the diamond, use SendMessage to increase the score for the player and destroy the diamond
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.SendMessage("IncreaseScore", SendMessageOptions.DontRequireReceiver);
            Destroy(gameObject);
        }
    }
}
