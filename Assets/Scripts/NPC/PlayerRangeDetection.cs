using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.AI;
using UnityEngine.UIElements;

public class PlayerRangeDetection : MonoBehaviour
{
    public GameObject player;

    public float rotateSpeed = 10f;
    public float currentRotation = 0f;

    private SpriteRenderer spriteRenderer;
    private Vector2 playerPosition;
    private Vector2 npcPosition;
    private Vector2 vectorBetweenCharacterAndNPC;
    private float chaseRadius = 10f;
    private float chaseSpeed = 3f;
    private float stoppingDistance = 1.5f;
    private bool chasePlayer;
    public float angle;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
       playerPosition = player.transform.position;
       npcPosition = transform.position;
       vectorBetweenCharacterAndNPC = playerPosition - npcPosition;
        
       if (chasePlayer)
        {
            spriteRenderer.color = Color.yellow;
            RotateTowardsPlayer();

            Debug.DrawRay(transform.position, vectorBetweenCharacterAndNPC, Color.yellow);
            Debug.DrawRay(transform.position, transform.up, Color.green);
            Debug.DrawRay(transform.position, Vector2.up, Color.red);

            if (vectorBetweenCharacterAndNPC.magnitude > stoppingDistance)
            {
                transform.Translate(vectorBetweenCharacterAndNPC.normalized * chaseSpeed * Time.deltaTime, Space.World);
            }
        }

        if (vectorBetweenCharacterAndNPC.magnitude < chaseRadius)
       {
           chasePlayer = true;
       }
       else
       {
           chasePlayer = false;
           spriteRenderer.color = Color.blue;
       }
    }

    private void RotateTowardsPlayer()
    {
        angle = Vector2.SignedAngle(Vector2.up, vectorBetweenCharacterAndNPC);
        Quaternion targetRotation = Quaternion.Euler(0, 0, angle);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);


    }

    public float GetDistanceToPlayer() { return vectorBetweenCharacterAndNPC.magnitude; }
    public Vector2 GetDirectionToPlayer() { return vectorBetweenCharacterAndNPC.normalized; }
    public bool GetChasePlayer() { return chasePlayer; }
    
}
