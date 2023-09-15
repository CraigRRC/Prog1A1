using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UIElements;

public class WanderBehaviour : MonoBehaviour
{
    public float wanderRange = 5f;

    private PlayerRangeDetection playerRangeDetector;
    private Vector2 originPosition;
    private Vector2 lastKnownLocation;
    private Vector2 targetPosition;
    private Vector2 vectorToTargetPosition;
    private float distanceToOrigin;
    private float targetMagnitude;
    private bool hasPatrolTarget = false;
    private float moveSpeed = 1f;
    private bool returnToOrigin = false;
    

    private void Awake()
    {
        //Get reference to the player range detection object.
        playerRangeDetector = GetComponent<PlayerRangeDetection>();
        //Set our origin position.
        originPosition = (Vector2)transform.position;
    }

    void Update()
    {
        if (NotChasingPlayer())
        {
            if (!hasPatrolTarget)
            {
                SetPatrolTarget();
            }
            else
            {
                if (returnToOrigin)
                {
                    ReturnToOriginLocation();
                }
                else
                {
                    Wander();
                }
                if (ReachedPatrolPoint())
                {
                    //Once the NPC has come close enough to it's target, we look for a new target.
                    hasPatrolTarget = false;
                }
            }
        }
        else
        {
            returnToOrigin = true;
        }

    }

    //Check to see if we are currently chasing the player.
    private bool NotChasingPlayer()
    {
        return !playerRangeDetector.GetChasePlayer();
    }

    //True if the distance between us and the target is less than 0.1f
    private bool ReachedPatrolPoint()
    {
        return targetMagnitude < 0.1f;
    }

    //Function that is called when we want the NPC to wander around.
    private void Wander()
    {
        //Make a new vector which holds the distance between our target vector, and the vector of our NPC's location.
        vectorToTargetPosition = targetPosition - (Vector2)transform.position;
        //Translate the direction of that newly acquired vector, and multiply it by our movespeed to get it's new magnitude as frame independant.
        transform.Translate(vectorToTargetPosition.normalized * moveSpeed * Time.deltaTime);
        Debug.DrawRay(transform.position, vectorToTargetPosition);
        //Cache the magnitude of this vector (this vector is the distance and direction from my NPC to their target location.)
        targetMagnitude = vectorToTargetPosition.magnitude;
        
    }
    //Function that is called to set a new patrol target.
    private void SetPatrolTarget()
    {
        //Find a new target with a radius of 5f in a circle around the npc.
        targetPosition = Random.insideUnitCircle * wanderRange;
        hasPatrolTarget = true;
    }

    //Function that rotates the npc back to it's original rotation, and also moves the NPC back to it's original location.
    private void ReturnToOriginLocation()
    {
        //Rotate the NPC's current rotation, towards 0 rotation (which is what it starts with)
        Quaternion targetRotation = Quaternion.Euler(0f, 0f, 0f);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 50f * Time.deltaTime);
        //Get location where we are currently
        lastKnownLocation = (Vector2)transform.position;
        //Get the direction and distance to our origin
        Vector2 vectorToOrigin = originPosition - lastKnownLocation;
        distanceToOrigin = vectorToOrigin.magnitude;
        //Translate to this location
        transform.Translate(vectorToOrigin.normalized * moveSpeed * Time.deltaTime);
        //Check to see if we've reached our origin point.
        if (distanceToOrigin <= 0.05f)
        {
            //We've returned.
            returnToOrigin = false;
        }
    }
}