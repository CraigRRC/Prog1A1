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
    public bool destinationReached = false;
    public float npcMoveSpeed = 1f;
    public float runningTimer = 0f;
    public float npcMoveTimer = 10f;

    // Start is called before the first frame update
    void Start()
    {
        npcStartingPosition = transform.position;
        runningTimer = 0f;
        
    }

    // Update is called once per frame
    void Update()
    {
        //have my timer begin counting
        runningTimer += Time.deltaTime;
        //get my current position
        npcStartingPosition = transform.position;
        //get my new location randomly
        npcNewPosition = Random.insideUnitSphere;
        //take apart my new location vector to direction and magnitude.
        directionOfWander = npcNewPosition.normalized;
        //multiply my move speed to the new location's magnitude, and store this as a new vector2
        randomlyGeneratedPosition = directionOfWander * npcMoveSpeed;
        //translate the normalized vector of my new location and my magnitude.
        if(runningTimer <= 10f)
        {
            transform.Translate(randomlyGeneratedPosition * Time.deltaTime);
        }
        else
        {
            runningTimer = 0f;
        }
        
    }
}
