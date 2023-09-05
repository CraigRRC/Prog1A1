using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Vector2 playerInput;
    public Vector2 cleanedPlayerInput;
   
    public float cleanedPlayerMagnitude;
    public float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        cleanedPlayerMagnitude = Mathf.Min(playerInput.magnitude, 1f);
        cleanedPlayerInput = playerInput.normalized * cleanedPlayerMagnitude;
        transform.Translate(cleanedPlayerInput * Time.deltaTime * speed);
    }
}
