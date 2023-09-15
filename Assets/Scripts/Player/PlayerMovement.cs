using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;

    // Update is called once per frame
    void Update()
    {
        //Handling input while cleaning the corner vectors so that all directions are the same.
        Vector2 playerInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        float cleanedPlayerMagnitude = Mathf.Min(playerInput.magnitude, 1f);
        Vector2 cleanedPlayerInput = playerInput.normalized * cleanedPlayerMagnitude;
        transform.Translate(cleanedPlayerInput * Time.deltaTime * speed);
    }
}
