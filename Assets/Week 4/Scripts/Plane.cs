using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Plane : MonoBehaviour
{
    public List<Vector2> points;
    Vector2 lastPosition;
    public float pointThreshold = 0.2f;

    LineRenderer lineRenderer;
    Rigidbody2D rigidbody;
    Vector2 currentPosition;

    public float speed = 1;

    public AnimationCurve landing;
    float timerValue;

    SpriteRenderer spriteRenderer;
    public GameObject circle;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);

        rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        circle.SetActive(false);
    }

    private void FixedUpdate()
    {
        speed = Random.Range(1, 4);

        currentPosition = transform.position;

        if (points.Count > 0)
        {
            Vector2 direction = points[0] - currentPosition;
            float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            rigidbody.rotation = -angle;
        }

        rigidbody.MovePosition(rigidbody.position + (Vector2)transform.up * speed * Time.deltaTime);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            timerValue += 0.5f * Time.deltaTime;
            float interpolation = landing.Evaluate(timerValue);

            if (transform.localScale.z < 0.1f)
            {
                Destroy(gameObject);
            }

            transform.localScale = Vector3.Lerp(Vector3.one, Vector3.zero, interpolation);
        }

        lineRenderer.SetPosition(0, transform.position);

        if (points.Count > 0)
        {
            if (Vector2.Distance(currentPosition, points[0]) < pointThreshold)
            {
                points.RemoveAt(0);

                for (int i = 0; i < lineRenderer.positionCount - 2; i++)
                {
                    lineRenderer.SetPosition(i, lineRenderer.GetPosition(i + 1));
                }

                lineRenderer.positionCount--;
            }
        }

        if (gameObject.transform.position.x > 9.5f || gameObject.transform.position.y > 5.0f ||
            gameObject.transform.position.x < -9.5f || gameObject.transform.position.y < -5.0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnMouseDown()
    {
        points = new List<Vector2>();
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);
    }

    private void OnMouseDrag()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Vector2.Distance(lastPosition, mousePos) > pointThreshold)
        {
            points.Add(mousePos);
            lineRenderer.positionCount++;
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, mousePos);
            lastPosition = mousePos;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        spriteRenderer.color = Color.red;
        
        if (!circle.activeInHierarchy)
        {
            circle.SetActive(true);
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Vector3.Distance(lastPosition, rigidbody.position) < pointThreshold)
        {
            Destroy(gameObject);
        }

        if(collision.gameObject.name == "Runway")
        {
            float interpolation = landing.Evaluate(timerValue);
            transform.position = Vector3.Lerp((Vector2)transform.position, (Vector2)rigidbody.position, interpolation);
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        spriteRenderer.color = Color.white;

        if (circle.activeInHierarchy)
        {
            circle.SetActive(false);
        }
    }
}
