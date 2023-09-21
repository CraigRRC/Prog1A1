using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollisionDetection : MonoBehaviour
{
    //Callback function for TriggerEnter2D. Sets the position of the object we collided to be world origin.
    private void OnTriggerEnter2D(Collider2D other)
    {
        other.transform.position = new Vector2(0f, 0f);
    }
}