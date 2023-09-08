using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.PackageManager;
using UnityEngine;

public class WanderBehaviour : MonoBehaviour
{
    public Vector2 startingPosition;
    public Vector2 targetPosition;
    public Vector2 vectorToTargetPosition;
    public float npcMag;
    public float targetMagnitude;
    public bool hasPatrolTarget = false;
    public float moveSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!hasPatrolTarget)
        {
            //Find a new target with a radius of 5f around the NPC.
            targetPosition = Random.insideUnitCircle * 5f;
            hasPatrolTarget = true;
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
            if(targetMagnitude < 0.1f)
            {
                hasPatrolTarget = false;
            }
        }
    }
}