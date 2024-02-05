using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarTrail : MonoBehaviour
{
    // I'll use my prefab game object in the inspector
    public GameObject starBadge;

    // 2 floats to count down the trail time (as well as starting trail timer to use it during countdown)
    float trailTimer;
    float startTrailTimer;

    // Start is called before the first frame update
    void Start()
    {
        // This is the best value for the star badge trail to render properly
        startTrailTimer = 0.3f;
    }

    // Update is called once per frame
    void Update()
    {
        // Basically, we know the time of trail is at 0 because I didn't give it a value
        if(trailTimer <= 0)
        {
            /* So if the trail timer is equal to or less than 0 (which it already is), instantiate
            the prefab I made using the starBadge game object */
            Instantiate(starBadge, transform.position, transform.rotation);

            // Set the trail timer equal to start trail timer immediately to count this down using deltaTime
            trailTimer = startTrailTimer;

            // Destroy the star badge prefab every 1.4 seconds so that the prefab doesn't stay in the game forever
            // I tried putting it inside the else if statement below but it rendered too many stars at one time
            Destroy(Instantiate(starBadge, transform.position, transform.rotation), 1.4f);
        }
        
        /* Or if the trail timer is greater than 0, then decrement it using deltaTime so that the trails
        can update every frame */
        else if(trailTimer > 0)
        {
            trailTimer -= Time.deltaTime;
        }
    }
}
