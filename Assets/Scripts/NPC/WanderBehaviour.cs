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

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!hasPatrolTarget)
        {
            targetPosition = Random.insideUnitCircle * 5f;
            hasPatrolTarget = true;
        }
        else
        {
            npcMag = startingPosition.magnitude;
            vectorToTargetPosition = targetPosition - (Vector2)transform.position;
            targetMagnitude = vectorToTargetPosition.magnitude;

            Debug.DrawRay(transform.position, targetPosition);

            if (targetMagnitude >= 0.1f)
            {
                transform.Translate(targetPosition.normalized * Time.deltaTime);
                
            }
        }
        

      
        
       
    }
}