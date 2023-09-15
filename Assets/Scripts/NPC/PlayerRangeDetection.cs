using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.AI;
using UnityEngine.UIElements;

public class PlayerRangeDetection : MonoBehaviour
{
    public GameObject player;
    public float rotateSpeed = 10f;
    public float chaseRadius = 10f;
    public float chaseSpeed = 3f;
    public float stoppingDistance = 1.5f;

    private SpriteRenderer spriteRenderer;
    private Vector2 vectorBetweenPlayerAndNPC;
    private bool isChasing;

    private void Awake()
    {
        //Grab reference to the sprite renderer object.
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        //Find the vector between our character and npc.
        Vector2 playerPosition = player.transform.position;
        Vector2 npcPosition = transform.position;
        vectorBetweenPlayerAndNPC = playerPosition - npcPosition;

        if (isChasing)
        {
            //Differenciate between wandering/chasing/attacking.
            spriteRenderer.color = Color.yellow;
            RotateTowardsPlayer();

            //Debug rays for figuring out rotation.
            Debug.DrawRay(transform.position, vectorBetweenPlayerAndNPC, Color.yellow);
            Debug.DrawRay(transform.position, transform.up, Color.green);
            Debug.DrawRay(transform.position, Vector2.up, Color.red);

            if (HaveNotReachedChaseTarget())
            {
                transform.Translate(vectorBetweenPlayerAndNPC.normalized * chaseSpeed * Time.deltaTime, Space.World);
            }
        }

        if (PlayerWithinChaseRadius())
        {
            isChasing = true;
        }
        else
        {
            isChasing = false;
            //Set the color back to something more neutral.
            spriteRenderer.color = Color.blue;
        }
    }

    //Returns true if the player is within our chase radius.
    private bool PlayerWithinChaseRadius()
    {
        return vectorBetweenPlayerAndNPC.magnitude < chaseRadius;
    }

    //Returns true if we are still chasing the target, Stops the NPC just shy of the player so that we don't go inside.
    private bool HaveNotReachedChaseTarget()
    {
        return vectorBetweenPlayerAndNPC.magnitude > stoppingDistance;
    }

     //Rotates based on the signed angle between vector2.up and our vector between our player and NPC.
    private void RotateTowardsPlayer()
    {
        float angle = Vector2.SignedAngle(Vector2.up, vectorBetweenPlayerAndNPC);
        Quaternion targetRotation = Quaternion.Euler(0, 0, angle);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
    }
    
    //Public accessors.
    public float GetDistanceToPlayer() { return vectorBetweenPlayerAndNPC.magnitude; }
    public Vector2 GetDirectionToPlayer() { return vectorBetweenPlayerAndNPC.normalized; }
    public bool GetIsChasing() { return isChasing; }
    
}
