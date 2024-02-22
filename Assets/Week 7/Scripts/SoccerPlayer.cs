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

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Selected(false);
    }

    private void OnMouseDown()
    {
        Selected(true);
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
}
