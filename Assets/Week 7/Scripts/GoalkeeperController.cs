using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalkeeperController : MonoBehaviour
{
    public Rigidbody2D rigidbody;

    public static SoccerPlayer SelectedPlayer { get; private set; }

    public static void SetSelectedPlayer(SoccerPlayer player)
    {
        if (SelectedPlayer != null)
        {
            SelectedPlayer.Selected(false);
        }

        SelectedPlayer = player;
        SelectedPlayer.Selected(true);
    }

    public void FixedUpdate()
    {
        if (SelectedPlayer == null) return;

        /* Find the magnitude of the line between the center goal line and the selected player and
        multiply it by half of the magnitude */
        float magnitude = ((Vector2)transform.position +
            (Vector2)SelectedPlayer.transform.position).magnitude * 0.5f;

        // Find the direction from the center of goal line and the selected player, and then normalize it
        Vector2 direction = magnitude * ((Vector2)transform.position +
            (Vector2)SelectedPlayer.transform.position).normalized;

        // Make the rigidbody position equal to the direction vector
        rigidbody.position = direction;
    }

    // Update is called once per frame
    private void Update()
    {
        //rigidbody.position = ((Vector2)goalkeeper.transform.position -
        //(Vector2)SelectedPlayer.transform.position).normalized * 0.5f;
    }
}
