using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UIElements;

public class WanderBehaviour : MonoBehaviour
{
    PlayerRangeDetection playerRangeDetector;

    public Vector2 originPosition;
    public Vector2 lastKnownLocation;
    public Vector2 targetPosition;
    public Vector2 vectorToTargetPosition;
    public float distanceToOrigin;
    public float npcMag;
    public float targetMagnitude;
    public bool hasPatrolTarget = false;
    public float moveSpeed = 1f;
    public bool returnToOrigin = false;

    private void Awake()
    {
        playerRangeDetector = GetComponent<PlayerRangeDetection>();
        originPosition = (Vector2)transform.position;
    }

    void Update()
    {
        if (!playerRangeDetector.GetChasePlayer())
        {
            if (!hasPatrolTarget)
            {
                //Find a new target with a radius of 5f around the NPC.
                targetPosition = Random.insideUnitCircle * 5f;
                hasPatrolTarget = true;
            }
            else
            {
                if (returnToOrigin)
                {
                    //Rotate
                    Quaternion targetRotation = Quaternion.Euler(0f, 0f, 0f);
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 50f * Time.deltaTime);

                    //get location where we are currently
                    lastKnownLocation = (Vector2)transform.position;
                    //get the direction and distance to our origin
                    Vector2 vectorToOrigin = originPosition - lastKnownLocation;
                    distanceToOrigin = vectorToOrigin.magnitude;
                    //translate to this location
                    transform.Translate(vectorToOrigin.normalized * moveSpeed * Time.deltaTime);
                    //check to see if we've reached our origiin point.
                    if (distanceToOrigin <= 0.05f)
                    {
                        //we've returned.
                        returnToOrigin = false; 
                    }
                }
                else
                {
                    //Make a new vector which holds the distance between our target vector, and the vector of our NPC's location.
                    vectorToTargetPosition = targetPosition - (Vector2)transform.position;
                    //Translate the direction of that newly acquired vector, and multiply it by our movespeed to get it's new magnitude as frame independant.
                    transform.Translate(vectorToTargetPosition.normalized * moveSpeed * Time.deltaTime);
                    Debug.DrawRay(transform.position, vectorToTargetPosition);
                    //Cache the magnitude of this vector (this vector is the distance and direction from my NPC to their target location.)
                    targetMagnitude = vectorToTargetPosition.magnitude;
                    //Once the NPC has come close enough to it's target, we look for a new target.
                }
                if (targetMagnitude < 0.1f)
                {
                    hasPatrolTarget = false;
                }
            }
        }
        else
        {
            returnToOrigin = true;
        }
       
    }
}