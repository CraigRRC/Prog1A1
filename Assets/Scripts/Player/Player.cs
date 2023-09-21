using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private SpriteRenderer playerRenderer;

    void Awake()
    {
        //Grabs a reference to our SpriteRenderer object and sets the player color.
        playerRenderer = GetComponent<SpriteRenderer>();
        playerRenderer.color = Color.black;
    }
}
