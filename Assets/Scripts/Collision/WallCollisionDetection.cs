using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollisionDetection : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
       Debug.Log("Object " + other.gameObject.name);

       WanderBehaviour npc = other.GetComponent<WanderBehaviour>();
       if (npc)
        {
            npc.hitWall = true;
        }
    }
}
