using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoccerPlayer : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    public Color selectedColor;
    public Color unselectedColor;

    Rigidbody2D rigidbody;

    public float speed = 500;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody = GetComponent<Rigidbody2D>();
        Selected(false);
    }

    private void OnMouseDown()
    {
        Controller.SetSelectedPlayer(this);
        GoalkeeperController.SetSelectedPlayer(this);
    }

    public void Selected(bool isPlayerSelected)
    {
        if (isPlayerSelected)
        {
            spriteRenderer.color = selectedColor;
        }

        else if (!isPlayerSelected)
        {
            spriteRenderer.color = unselectedColor;
        }
    }

    public void Move(Vector2 direction)
    {
        rigidbody.AddForce(direction * speed);
    }
}
