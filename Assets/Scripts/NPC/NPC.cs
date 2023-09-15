using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    private SpriteRenderer npcSpriteRenderer;

    void Start()
    {
        //Grabing a reference to our sprite renderer, and changing the colour to blue.
        npcSpriteRenderer = GetComponent<SpriteRenderer>();
        npcSpriteRenderer.color = Color.blue;
    }
}
