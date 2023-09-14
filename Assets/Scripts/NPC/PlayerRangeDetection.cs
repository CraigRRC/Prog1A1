using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.AI;
using UnityEngine.UIElements;

public class PlayerRangeDetection : MonoBehaviour
{
    public GameObject player;
    public WanderBehaviour npc;

    public float rotateSpeed = 50f;
    public float currentRotation = 0f;

    Vector2 playerPosition;
    Vector2 npcPosition;
    Vector2 vectorBetweenCharacterAndNPC;
    public float chaseRadius = 5f;
    public float chaseSpeed = 3f;
    public bool chasePlayer;
    public float angle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       playerPosition = player.transform.position;
       npcPosition = transform.position;

       vectorBetweenCharacterAndNPC = playerPosition - npcPosition;
        
       if (chasePlayer)
       {
            //gets me the correct rotation, but I seem to be moving in world space opposed to local?

            angle = Vector2.SignedAngle(Vector2.up, vectorBetweenCharacterAndNPC);

            if (angle < 0f)
            {
                currentRotation = 0; 
                currentRotation -= angle;
            }
            else if (angle > 1f)
            {
                currentRotation = 0;
                currentRotation += angle;
            }

            transform.rotation = Quaternion.Euler(0, 0, angle);

            
            Debug.DrawRay(transform.position, vectorBetweenCharacterAndNPC, Color.yellow);
            Debug.DrawRay(transform.position, transform.up, Color.green);
            Debug.DrawRay(transform.position, Vector2.up, Color.red);

            transform.Translate(vectorBetweenCharacterAndNPC.normalized * chaseSpeed * Time.deltaTime, Space.World);
           
       }

       if(vectorBetweenCharacterAndNPC.magnitude < chaseRadius)
       {
           chasePlayer = true;
       }
       else
       {
           chasePlayer = false;
           transform.rotation = Quaternion.Euler(0, 0, 0);
       }
    }
}
