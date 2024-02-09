using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    float timer;
    Vector2 randomizedMovement;
    float randomizedSpeed;

    Rigidbody2D rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector2(Random.Range(-5, 5), Random.Range(-5, 5));
        randomizedMovement = new Vector2(Random.Range(-4, 4), Random.Range(-4, 4));

        randomizedSpeed = Random.Range(1, 4);

        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rigidbody.MovePosition(rigidbody.position + randomizedMovement * randomizedSpeed * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > 5 && randomizedSpeed == 3 || timer > 5 && randomizedSpeed == 4)
        {
            Destroy(gameObject);
        }

        if (timer > 10 && randomizedSpeed == 1 || timer > 5 && randomizedSpeed == 2)
        {
            Destroy(gameObject);
        }

        if (transform.position.x <= -8.5)
        {
            transform.position = new Vector2(-8.5f, transform.position.y);
        }

        if (transform.position.x >= 8.5)
        {
            transform.position = new Vector2(8.5f, transform.position.y);
        }

        if (transform.position.y <= -4.5)
        {
            transform.position = new Vector2(transform.position.x, -4.5f);
        }

        if (transform.position.y >= 4.5)
        {
            transform.position = new Vector2(transform.position.x, 4.5f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Knight")
        {
            collision.gameObject.SendMessage("TakeDamage", 1, SendMessageOptions.DontRequireReceiver);
            Destroy(gameObject);
        }
    }
}
