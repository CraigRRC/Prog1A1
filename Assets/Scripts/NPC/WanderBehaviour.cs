using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.PackageManager;
using UnityEngine;

public class WanderBehaviour : MonoBehaviour
{
    Vector2 npcStartingPosition;
    public Vector2 npcNewPosition;
    public Vector2 directionOfWander;
    public Vector2 randomlyGeneratedPosition;
    public bool npcIsMoving = false;
    public bool destinationReached = true;
    public bool hitWall = false;
    public float npcMoveSpeed = 1f;
    public float runningTimer = 0f;
    public float npcMoveTimer = 3f;

    // Start is called before the first frame update
    void Start()
    {
        runningTimer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        //have my timer begin counting
        runningTimer += Time.deltaTime;
        if (destinationReached)
        {
            //get new vector pointing to a random location within a sphere.
            npcNewPosition = Random.insideUnitSphere;
            //take apart my new location vector and just grab the direction.
            directionOfWander = npcNewPosition.normalized;
            //multiply my move speed to the new location's direction, and store this as a new vector2
            randomlyGeneratedPosition = directionOfWander * npcMoveSpeed;
            //translate the normalized vector of my new location and my magnitude.
            destinationReached = false;
        }

        if (runningTimer <= npcMoveTimer)
        {
            transform.Translate(randomlyGeneratedPosition * Time.deltaTime);
        }
        else
        {
            runningTimer = 0f;
            destinationReached = true;
        }
        
        if (hitWall)
        {
            runningTimer = 0f;
            destinationReached = true;
            transform.Translate(new Vector2(0, 0) * Time.deltaTime);
            hitWall = false;
        }
    }
}
