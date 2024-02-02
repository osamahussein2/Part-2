using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Runway : MonoBehaviour
{
    public int score;
    public Transform plane;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.OverlapPoint(plane.position))
        {
            Destroy(plane);
            score++;
        }
    }
}
