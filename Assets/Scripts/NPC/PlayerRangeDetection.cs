using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRangeDetection : MonoBehaviour
{
    public GameObject player;
    public WanderBehaviour npc;

    Vector2 playerPosition;
    Vector2 npcPosition;
    Vector2 vectorThatIWant;
    float moveSpeed = 6f;
    bool chasePlayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       playerPosition = player.transform.position;
       npcPosition = transform.position;

       vectorThatIWant = playerPosition - npcPosition;

       if (chasePlayer)
       {
            transform.Translate(vectorThatIWant.normalized * moveSpeed * Time.deltaTime);
       }

       if(vectorThatIWant.magnitude < 5f)
       {
           Debug.Log("Player is within 5f");
            chasePlayer = true;
       }
        else
        {
            chasePlayer = false;
        }
    }
}
