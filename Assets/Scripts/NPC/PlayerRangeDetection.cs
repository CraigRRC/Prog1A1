using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.AI;
using UnityEngine.UIElements;

public class PlayerRangeDetection : MonoBehaviour
{
    public GameObject player;
    public WanderBehaviour npc;
    private SpriteRenderer spriteRenderer;

    public float rotateSpeed = 50f;
    public float currentRotation = 0f;

    Vector2 playerPosition;
    Vector2 npcPosition;
    private Vector2 vectorBetweenCharacterAndNPC;
    public float chaseRadius = 10f;
    public float chaseSpeed = 3f;
    public bool chasePlayer;
    public float angle;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
       playerPosition = player.transform.position;
       npcPosition = transform.position;

       vectorBetweenCharacterAndNPC = playerPosition - npcPosition;
        
       if (chasePlayer)
       {
            spriteRenderer.color = Color.yellow;

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
           spriteRenderer.color = Color.blue;
       }
    }

    public float GetDistanceToPlayer() { return vectorBetweenCharacterAndNPC.magnitude; }
    public Vector2 GetDirectionToPlayer() { return vectorBetweenCharacterAndNPC.normalized; }
}
