using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderBehaviour : MonoBehaviour
{
    Vector2 npcStartingPosition;
    public Vector2 npcNewPosition;
    public bool npcIsMoving = false;
    public bool destinationReached = false;
    public float npcMoveSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        npcStartingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
       

        if (!npcIsMoving)
        {
            npcNewPosition = (Random.insideUnitCircle * 5f).normalized * npcMoveSpeed;
            transform.Translate(npcNewPosition);
            npcIsMoving = true;
        }



        if (destinationReached)
        {
            npcIsMoving = false;
        }
       
    }
}
