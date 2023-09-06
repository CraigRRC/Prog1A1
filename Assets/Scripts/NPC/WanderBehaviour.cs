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
        npcNewPosition = new Vector2(1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(npcNewPosition);
    }
}
